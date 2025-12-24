using APIDAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApiPreJoinerB2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersDataController : ControllerBase
    {
        public readonly IUser _user;
        public UsersDataController(IUser user)
        {
            _user = user;
        }



        [HttpPost]
        public async Task<IActionResult> Create(APIDAL.Models.Users obj)
        {
            await _user.AddUser(obj);

         return Ok("User added successfully");  
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _user.GetUsers();
            return Ok(users);
        }   
    }
}
