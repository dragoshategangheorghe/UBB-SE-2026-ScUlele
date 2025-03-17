using BankApp.Server.DataAccess;
using BankApp.Server.DataAccess.Interfaces;
using BankApp.Server.Services.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Server.Controllers
{
    // This controller is just used for testing endpoints, have fun :) <3 B
    // THIS SHOULD NOT GO INTO PRODUCTION FOR ANY REASON WHATSOEVER, AFTER WE ARE DONE 
    // WITH TESTING WE CAN DELETE THIS FILE AND NOT CARE ABOUT MERGE CONFLICTS HERE
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("db")]
        public IActionResult TestDb([FromServices] AppDbContext db)
        {
            // TODO: implement test db logic
            return default !;
        }

        [HttpGet("user/find/{email}")]
        public IActionResult FindUser([FromServices] IUserDAO userDao, string email)
        {
            // TODO: implement find user logic
            return default !;
        }

        [HttpGet("hash/{text}")]
        public IActionResult TestHash([FromServices] IHashService hash, string text)
        {
            // TODO: implement test hash logic
            return default !;
        }

        [HttpGet("jwt/generate/{userId}")]
        public IActionResult TestJwtGenerate([FromServices] IJWTService jwt, int userId)
        {
            // TODO: implement test jwt generate logic
            return default !;
        }

        [HttpGet("jwt/validate/{token}")]
        public IActionResult TestJwtValidate([FromServices] IJWTService jwt, string token)
        {
            // TODO: implement test jwt validate logic
            return default !;
        }
    }
}