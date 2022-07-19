using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OaSys.API.Data;
using OaSys.API.Models;

namespace OaSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly OasysDBContext userDBContext;
        public UserController(OasysDBContext userDBContext)
        {
            this.userDBContext = userDBContext;
        }
        //Get All Cards
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userDBContext.User.ToListAsync();
            return Ok(users);
        }

        //Get single user
        [HttpGet("{id}")]
        [ActionName("GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var users = await userDBContext.User.FirstOrDefaultAsync(x => x.USER_ID == id);
            if(users != null)
            {
                return Ok(users);   
            }
            return NotFound("User not found");
        }

        //add single user
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await userDBContext.User.AddAsync(user);  
            await userDBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser),new { id = user.USER_ID}, user);      
        }

        //Updating a user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var existingUser = await userDBContext.User.FirstOrDefaultAsync(x => x.USER_ID == id);
            if (existingUser != null)
            {
                existingUser.USERNAME = user.USERNAME;
                existingUser.USER_PASSWORD = user.USER_PASSWORD;
                await userDBContext.SaveChangesAsync();
                return Ok(existingUser);
            }
            return NotFound("User Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await userDBContext.User.FirstOrDefaultAsync(x =>x.USER_ID == id);
            if (existingUser != null)
            {
                userDBContext.User.Remove(existingUser);
                await userDBContext.SaveChangesAsync();
                return Ok(existingUser);
            }
            return NotFound("User not found");
        }
    }
}
