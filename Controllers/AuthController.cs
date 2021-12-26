using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snap_n_go.Data;
using Snap_n_go.DTOs;
using Snap_n_go.Helpers;
using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository,JwtService jwtService )
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult RegisterAsync(RegisterDTO dto)
        {
            var exsistingUser =  _repository.getByEmail(dto.Email);
            if(exsistingUser != null)
            {
                return BadRequest(new
                {
                    statusCode = 422,
                    message = "Email already in use"
                });
            }
            var user = new User
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Email = dto.Email,
                Dob=dto.Dob,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            var u = _repository.create(user);
            return Ok(new
            {
                statusCode = 200,
                message = "Success",
            });
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _repository.getByEmail(dto.Email);
            if (user == null) return BadRequest(new
            {
                statusCode=401,
                message ="Invalid Credentials"
            });
            
            if(!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return Unauthorized(new
                {
                    statusCode = 401,
                    message = "Invalid Credentials"
                });
            }
            var jwt = _jwtService.Generate(user.Id);
            Response.Cookies.Append("token", jwt, new CookieOptions
            {
                HttpOnly=true
            });
            return Ok(new {
                statusCode=200,
                message= "Success",
                token=jwt
            });
        }

        [HttpGet("user")]
        public IActionResult User(string jwtString)
        {

            try
            {
                //var jwtString = Request.Cookies["token"];

                var token = _jwtService.Verify(jwtString);
                int userId = int.Parse(token.Issuer);
                var user = _repository.getById(userId);
                Console.WriteLine("Retrieved user:" + user.Email);
                return Ok(user);
            } catch (Exception e)
            {
                return Unauthorized();
            }
           
        }
        
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("token");
            return Ok(new
            {
                statusCode = 200,
                message = "Success"
            });
        }
    }
}
