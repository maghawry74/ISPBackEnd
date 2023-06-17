using ISP.BL;
using ISP.BL.Dtos.Users;
using ISP.BL.Services.UserPermissionsService;
using ISP.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static ISP.BL.Constants.Helper;

namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : Controller
    {
        
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IUserService userService; 
        private readonly IConfiguration configuration;
        public UserController(UserManager<User> userManager,RoleManager<Role> roleManager ,
            IUserService userService, IConfiguration configuration)
        {
            this.userManager = userManager;                  
            this.roleManager = roleManager;
            this.userService = userService;
            this.configuration = configuration;
        }

        #region SuperAdmin Register 
        [HttpPost]
        [Route("SuperAdminRegister")]
        [AllowAnonymous]
        public async Task<ActionResult> SuperAdminRegister(AdminRegisterDto adminRegisterDto)
        {
            var user = new User
            {
                UserName = adminRegisterDto.UserName,
                Email = adminRegisterDto.Email,
                Status = true,
                PhoneNumber = adminRegisterDto.PhoneNumber,          
                EmailConfirmed = true,
                BranchId = adminRegisterDto.BranchId,

            };

            //Check User Email
            var getUser = await userManager.FindByEmailAsync(adminRegisterDto.Email);
            if (getUser != null)
                return Problem(detail: "This Email is Exist!", statusCode: 404,
                  title: "error", type: "null reference");


            //Create User
            var created =  userManager.CreateAsync(user, adminRegisterDto.Password);
                if (!created.Result.Succeeded)
                {
                    return BadRequest(created.Result.Errors);
                }
              
            //Add Role To User
            var addedRole = userManager.AddToRoleAsync(user,Roles.SuperAdmin.ToString());
            if (!addedRole.Result.Succeeded)
                return Problem(detail: "Error acording add to role!", statusCode: 404,
                   title: "error", type: "null reference");




            var role = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
            if (role == null)
                return Problem(detail: "Error acording adding role!", statusCode: 404,
                  title: "error", type: "null reference");


            //Add Claims To Role 
            var isSeddedClaims = await userService.SeedAdminClaimsAsync(Roles.SuperAdmin.ToString());
            if (!isSeddedClaims)                
                return Problem(detail: "Invalid Seeding Claims, Check Your Role Name!", statusCode: 404,
                  title: "error", type: "null reference");


            var claims = new List<Claim>
            {

               new Claim(ClaimTypes.NameIdentifier, user.Id),
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(ClaimTypes.Role, role.Id)
            };

            await userManager.AddClaimsAsync(user, claims);

            return Ok();
        }
        #endregion
                                                                     
        #region User Register 
        [HttpPost]
        [Route("UserRegister")]
        [AllowAnonymous]
        public async Task<ActionResult> UserRegister(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Status = true,
                PhoneNumber = registerDto.PhoneNumber,
                EmailConfirmed = true,
                BranchId = registerDto.BranchId,
                
            };


            //Check User Role
            var checkRole = await roleManager.FindByNameAsync(registerDto.RoleName);
            if (checkRole == null)
                 return Problem(detail: "This Role Name does Exist!", statusCode: 404,
                   title: "error", type: "null reference");

            //Check User Email
            var getUser = await userManager.FindByEmailAsync(registerDto.Email);
            if (getUser != null )
                return Problem(detail: "This Email is Exist!", statusCode: 404,
                  title: "error", type: "null reference");
            

            //Create User
            var created = userManager.CreateAsync(user, registerDto.Password);
            if (!created.Result.Succeeded)
            {
                return BadRequest(created.Result.Errors);
            }

            //Add Role To User
            var addedRole = userManager.AddToRoleAsync(user, registerDto.RoleName);
            if (!addedRole.Result.Succeeded)
                return Problem(detail: "Error acording add to role!", statusCode: 404,
                  title: "error", type: "null reference");
            

            var role = await roleManager.FindByNameAsync(registerDto.RoleName);
            if (role == null)
                return Problem(detail: "Error acording adding role!", statusCode: 404,
                   title: "error", type: "null reference");


            var claims = new List<Claim>
            {

            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, role.Id)
            };

            await userManager.AddClaimsAsync(user, claims);

            return Ok();
        }
        #endregion

        #region Login
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginData)
        {
            var user = await userManager.FindByNameAsync(loginData.UserName);

            if (user == null)
            {
                return Unauthorized();
            }

            var isAuthenticated = await userManager.CheckPasswordAsync(user, loginData.Password);

            if (isAuthenticated == false)
            {
                return Unauthorized();
            }

            //Get User Claims
            var getUserClaims = await userManager.GetClaimsAsync(user);
            List<ClaimDto> userClaims = new List<ClaimDto>(); 

            foreach(var claim in getUserClaims)
            {
                userClaims.Add(new ClaimDto { claimType = claim.Type, Value = claim.Value });
            }


            //Get Role Claims
            var roleName = userManager.GetRolesAsync(user).Result.FirstOrDefault();
            var role = await roleManager.FindByNameAsync(roleName);

            if (role == null)
                return Problem(detail: "Role is null", statusCode: 404,
                   title: "error", type: "null reference");


            var getRoleClaims = await roleManager.GetClaimsAsync(role);
            
            List<string> roleClaims = new List<string>();

            foreach (var claim in getRoleClaims)
            {
                roleClaims.Add(claim.Value);
            }


            // Secret Key
            var secretKeyString = configuration.GetValue<string>("SecretKey");
            var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);


            // Create secretKey, Algorithm 
            var signingCredentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);


            var expireDate = DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(claims: getUserClaims, expires: expireDate, signingCredentials: signingCredentials);
           

            // Casting Token 
            var tokenHandler = new JwtSecurityTokenHandler();

            return new TokenDto(tokenHandler.WriteToken(token), expireDate, userClaims , roleClaims);
        }

        #endregion

        //[HttpGet]
        //[Route("GetAll")]
        //[AllowAnonymous]
        //public async Task<ActionResult<List<ReadUserDto>>> GetAll()
        //{
        //    return await userService.GetAll();
           
        //}

    }
}
