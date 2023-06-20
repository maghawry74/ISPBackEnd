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


namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : Controller
    {
        #region Con

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
        #endregion


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
                PhoneNumber = adminRegisterDto.PhoneNumber,          
                EmailConfirmed = true,
                BranchId = adminRegisterDto.BranchId,
                Status = true

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
            var addedRole = userManager.AddToRoleAsync(user,"SuperAdmin");
            if (!addedRole.Result.Succeeded)
                return Problem(detail: "Error acording add to role!", statusCode: 404,
                   title: "error", type: "null reference");


            
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
                PhoneNumber = registerDto.PhoneNumber,
                EmailConfirmed = true,
                BranchId = registerDto.BranchId,
                Status = true,

            };


            //Check User Role
            var checkRole = await roleManager.FindByIdAsync(registerDto.RoleId);
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
            var addedRole = userManager.AddToRoleAsync(user,checkRole.Name);
            if (!addedRole.Result.Succeeded)
                return Problem(detail: "Error acording add to role!", statusCode: 404,
                  title: "error", type: "null reference");

            

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
            var userClaims = await userManager.GetClaimsAsync(user);

            //Delete User claims
            await userManager.RemoveClaimsAsync(user, userClaims);

            //Get Role   
            var roleName = userManager.GetRolesAsync(user).Result.FirstOrDefault();
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
                return Problem(detail: "Error according get role!", statusCode: 404,
                   title: "error", type: "null reference");

            //Get Role claims
            var roleClaims = await roleManager.GetClaimsAsync(role);

            var claims = new List<Claim>
            {

                new Claim("Id", user.Id),
                new Claim("Name", user.UserName),
                new Claim("RoleName", roleName),

            };

            claims.AddRange(roleClaims);

            await userManager.AddClaimsAsync(user, claims);



            // Secret Key
            var secretKeyString = configuration.GetValue<string>("SecretKey");
            var secretyKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString ?? string.Empty);
            var secretKey = new SymmetricSecurityKey(secretyKeyInBytes);


            // Create secretKey, Algorithm 
            var signingCredentials = new SigningCredentials(secretKey,
                SecurityAlgorithms.HmacSha256Signature);


            var expireDate = DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(claims: claims, expires: expireDate, signingCredentials: signingCredentials);
           

            // Casting Token 
            var tokenHandler = new JwtSecurityTokenHandler();

            return new TokenDto(tokenHandler.WriteToken(token), expireDate);

            //return new TokenDto(tokenHandler.WriteToken(token), expireDate, userClaims.ToList());

        }

        #endregion

        [HttpGet]
        [Route("GetAll")]
        [AllowAnonymous]
        public async Task<ActionResult<List<ReadUserDto>>> GetAll()
        {
            return await userService.GetAll();

        }

    }
}
