using ISP.BL.Dtos.Users;
using ISP.BL.Services.UserPermissionsService;
using ISP.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static ISP.API.Helpers.Helper;


namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IUserPermissionsService userPermissions; 
        private readonly IConfiguration configuration;
        public UserController(UserManager<User> userManager,RoleManager<Role> roleManager ,
            IUserPermissionsService userPermissions, IConfiguration configuration)
        {
            this.userManager = userManager;                  
            this.roleManager = roleManager;
            this.userPermissions = userPermissions;
            this.configuration = configuration;
        }

        #region SuperAdmin Register 
        [HttpPost]
        [Route("SuperAdminRegister")]
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
                return BadRequest("This Email is Exist!");


            //Create User
            var created =  userManager.CreateAsync(user, adminRegisterDto.Password);
                if (!created.Result.Succeeded)
                {
                    return BadRequest(created.Result.Errors);
                }
              
            //Add Role To User
            var addedRole = userManager.AddToRoleAsync(user, Roles.SuperAdmin.ToString());
            if (!addedRole.Result.Succeeded)
                return BadRequest("Error acording add to role!  " + created.Result.Errors);

            var role = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());


            //Add Claims To Role 
            var isSeddedClaims = await userPermissions.SeedClaimsAsync(Roles.SuperAdmin.ToString());
            if (!isSeddedClaims)
                return BadRequest("Invalid Seeding Claims, Check Your Role Name!");


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
                return BadRequest("This Role Name does Exist!");

            //Check User Email
            var getUser = await userManager.FindByEmailAsync(registerDto.Email);
            if (getUser != null )            
                return BadRequest("This Email is Exist!");

            //Create User
            var created = userManager.CreateAsync(user, registerDto.Password);
            if (!created.Result.Succeeded)
            {
                return BadRequest(created.Result.Errors);
            }

            //Add Role To User
            var addedRole = userManager.AddToRoleAsync(user, registerDto.RoleName);
            if (!addedRole.Result.Succeeded)            
                return BadRequest("Error acording add to role!  "+created.Result.Errors);

            var role = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());


            //Add Claims To Role 
            var isSeddedClaims = await userPermissions.SeedClaimsAsync(registerDto.RoleName);
            if (!isSeddedClaims)
                return BadRequest("Invalid Seeding Claims, Check Your Role Name!");


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

            
            var claims = await userManager.GetClaimsAsync(user);
            List<ClaimDto> result = new List<ClaimDto>(); 

            foreach(var claim in claims)
            {
                result.Add(new ClaimDto { claimType = claim.Type, Value = claim.Value });
            }


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

            return new TokenDto(tokenHandler.WriteToken(token), expireDate, result);
        }

        #endregion

    }
}
