using Bll_Services.IServices;
using Bll_Services.Services;
using DalRepository.models;
using DTO_Enteties_Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [ApiController]
   
    [Route("users")]
    public class UserController : Controller
    {
        //private UserIService ser = new UserService();

        private UserIService ser;

        public UserController(UserIService service)
        {
            ser = service;
        }

        [HttpPost("add")]
        public Task<bool> Add([FromBody] UserDTO user)
        {
            return ser.addAsync(user);
        }
        [HttpPost("find")]
        public Task<bool> Find([FromBody] UserDTO user)
        {
            return ser.getUserByIdAsync(user);
        }



        //[HttpGet("")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = ser.GetUsersAsync();
        //    return Ok(result);
        //}
    }
}
