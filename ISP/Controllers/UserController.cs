using ISP.BL.Dtos.Users;
using ISP.BL.Services.UserPermissionsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : Controller
    {
        #region Con

       
        private readonly IUserService userService; 
    
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        #endregion
                                                   
        #region User Register 
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> UserRegister(RegisterDto registerDto)
        {
           var isRegister = await userService.UserRegister(registerDto);
            if (isRegister == 1)
                return Problem(detail: "Error in checkRole", statusCode: 404,
                   title: "error", type: "null reference");

            if (isRegister == 2)
                return Problem(detail: "Error in getUser(Email is Existing!) ", statusCode: 404,
                  title: "error", type: "null reference");

            if (isRegister == 3)
                return Problem(detail: "Error in Ceeading Password!", statusCode: 404,
                  title: "error", type: "null reference");

            if (isRegister == 4)
                return Problem(detail: "Error in Adding Role! ", statusCode: 404,
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
            var isLogin = await userService.Login(loginData);

            if (isLogin == null)            
                return Unauthorized();


            return isLogin;

            
        }

        #endregion

        [HttpGet]

        [AllowAnonymous]
        public async Task<ActionResult<List<ReadUserDto>>> GetAll()
        {
            return await userService.GetAll();

        }

        [HttpGet("{id}")]
       
        public async Task<ActionResult<ReadUserDto>> GetById(string id)
        {
            var user = await userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }


        [HttpPut("{id}")]        
        public async Task<ActionResult> Edit(string id, UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.Id)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            var updated = await userService.Update(id, updateUserDto);

            if (updated == null)
            {
                return NotFound();
            }

            return Ok();

        }

        [HttpDelete("{id}")]        
        public async Task<ActionResult> Delete(string id)
        {
            var deleteUser = await userService.Delete(id);

            if (deleteUser == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            return Ok();
          }

    }
}
