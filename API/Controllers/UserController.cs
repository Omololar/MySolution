using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//api/User
    public class UserController : ControllerBase
    {
        private readonly APIContext _context;
        public UserController(APIContext context)
        {
            _context = context;
        }

        [HttpGet("alluser")]// /alluser
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.OrderByDescending(u => u.CreationDate).ToListAsync();
            if (users.Count == 0)
            {
                return BadRequest("No users found");
            }
            return Ok(users);
        }

        [HttpGet("{id}")] // /5
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user =await _context.Users.FindAsync(id);
            if (user == null) { return BadRequest("User not found"); }
            return Ok(user);
        }


        [HttpPost("addUser")] // /addUser
        public async Task<ActionResult> AddUser(User user)
        {

            _context.Users.Add(user);
            _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}