using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<User> usermanager, RoleManager<IdentityRole> rolemanager, IConfiguration configuration)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
            _configuration = configuration;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Kindly ensure all details are properly filled" });
            }

            var userExist = await _usermanager.FindByNameAsync(model.Username);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User exist" });
            }

            var newUser = new User
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                Username = model.Username,
            };

            var createUser = await _usermanager.CreateAsync(newUser, model.Password);

            if (!createUser.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "could not create user" });
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully" });
        }


    }
}
