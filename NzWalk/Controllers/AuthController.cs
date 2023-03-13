using Microsoft.AspNetCore.Mvc;
using NzWalk.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Controllers
{
    [ApiController]
    [Route("controller")] 
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Models.DTO.LoginRequest loginRequest)
        {
            //check user is Auth
            var user= await _userRepository.AuthenticateAsync(loginRequest.UserName, loginRequest.Password);

            if (user!=null)
            {
                //Genrate JWT TOKEN
                var token = _tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }
            return BadRequest("USerNAme and PAss");
        }
    }
}
