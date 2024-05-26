using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.Domain.Entities;
using QuizMaster.Service.DTOs.Users;
using QuizMaster.Service.Services.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizMaster.TelegramBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController(IUserService userService) : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await userService.RetrieveAllAsync());
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDto value)
        {
            return Ok(await userService.CreateAsync(value));
        }
    }
}
