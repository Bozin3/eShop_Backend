using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop_Backend.Models.Requests;
using eShop_Backend.Models.Responses;
using eShop_Backend.Repositories;
using eShop_Backend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHandler passwordHandler;
        private readonly IAuthTokenHandler tokenHandler;
        public AuthController(IUserRepository userRepository, IPasswordHandler passwordHandler, IAuthTokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.passwordHandler = passwordHandler;
            this.tokenHandler = tokenHandler;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userRepository.GetUserByEmail(loginRequest.Email);

            if (user == null)
            {
                return Ok(new LoginResponse { Success = false, Message = "User not found!" });
            }

            if (!passwordHandler.CheckValidPassword(loginRequest.Password, user))
            {
                return Ok(new LoginResponse { Success = false, Message = "Wrong user/password combination, please try again!" });
            }

            return Ok(new LoginResponse { Success = true, Message = null, Token = tokenHandler.CreateToken(user) });
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest registerRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            byte[] passwordHash, passwordSalt;
            passwordHandler.CreatePasswordHash(registerRequest.Password, out passwordHash, out passwordSalt);

            var user = UserMapper.CreateUserFromRequest(registerRequest);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            if (await userRepository.AddUser(user) > 0)
            {
                return Ok(new RegisterResponse { Success = true, Message = null });
            }
            else
            {
                return Ok(new RegisterResponse { Success = false, Message = "Something went wrong, please try again" });
            }
        }

    }
}