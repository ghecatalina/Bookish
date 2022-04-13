using Api.Dto;
using Application.Users.Queries.GetUsers;
using Application.Users.Queries.LoginUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]UserAuthDto user)
        {
            if (user == null)
                return BadRequest("Invalid client request");
            var query = new LoginUserQuery { Email = user.RegularUserEmail, Password = user.RegularUserPassword };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return BadRequest("Invalid credidentials");
            }
            if (user.RegularUserEmail == result.Email && user.RegularUserPassword == result.Password) { 
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("shfjkwnkf23t@4554vw#"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5001",
                        audience: "https://localhost:5001",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
