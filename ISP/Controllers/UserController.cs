﻿using ISP.API.Helpers;
using ISP.BL.Dtos.Users;
using ISP.BL.Services.RoleService;
using ISP.DAL;
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
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IRoleService roleService;
        public UserController(UserManager<User> userManager, IConfiguration configuration,
            IRoleService roleService, RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.roleService = roleService;
            this.roleManager = roleManager;
        }

        #region Admin Register 
        [HttpPost]
        [Route("AdminRegister")]
        public async Task<ActionResult> AdminRegister(AdminRegisterDto adminRegisterDto)
        {
            var user = new User
            {
                UserName = adminRegisterDto.UserName,
                Email = adminRegisterDto.Email,
                Status = true,
                PhoneNumber = adminRegisterDto.PhoneNumber,          
                EmailConfirmed = true

            };
            

            var getUser = await userManager.FindByEmailAsync(adminRegisterDto.Email);

            if (getUser == null)
            {
                var created = await userManager.CreateAsync(user, adminRegisterDto.Password);
                if (!created.Succeeded)
                {
                    return BadRequest(created.Errors);
                }

                await userManager.AddToRoleAsync(user, "SuperAdmin");
                user.RoleId = user.Role?.Id;                              

            }

            var claims = new List<Claim>
            {

            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role?.Name)
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
                Status =true,
                PhoneNumber = registerDto.PhoneNumber,
                BranchId = registerDto.BranchId,
                RoleId = registerDto.RoleId,
                EmailConfirmed = true
            };
            var created = await userManager.CreateAsync(user, registerDto.Password);

            if (!created.Succeeded)
            {
                return BadRequest(created.Errors);
            }

            var role = roleService.GetRoleNameByID(registerDto.RoleId);

            var claims = new List<Claim>
            {

            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role,role)
            };

            await userManager.AddClaimsAsync(user, claims);

            return Ok();
        }
        #endregion

    }
}
