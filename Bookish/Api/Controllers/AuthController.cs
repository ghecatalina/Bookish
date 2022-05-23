﻿using Api.Dto;
using Api.Settings;
using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly JwtSettings _jwtSettings;
        public AuthController(IMapper mapper, UserManager<User> userManager,
            RoleManager<Role> roleManager, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;

        }
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthDto userLogin)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userLogin.RegularUserEmail);
            if (user == null)
                return NotFound("User not found");
            var loginResult = await _userManager.CheckPasswordAsync(user, userLogin.RegularUserPassword);
            if (loginResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return Ok( new {tk = GenerateJwt(user, roles) , Id = user.Id, role = roles});
            }
            return BadRequest("Invalid credentials.");
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegister)
        {
            var user = _mapper.Map<UserRegisterDto, User>(userRegister);
            var userCreateResult = await _userManager.CreateAsync(user, userRegister.Password);
            var result = await _userManager.AddToRoleAsync(user, "regular");
            if (userCreateResult.Succeeded)
                return Created(string.Empty, string.Empty);
            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userUpdate)
        {
            var user = await _userManager.FindByIdAsync(userUpdate.Id.ToString());
            if (user == null)
                return BadRequest();
            user.Name = userUpdate.Name;
            user.ProfilePicture = userUpdate.ProfilePicture;
            await _userManager.UpdateAsync(user);
            if (userUpdate.Password != "")
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, userUpdate.Password);
            }
            return Ok(user);

        }

        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Role name should be provided.");
            }

            var newRole = new Role
            {
                Name = roleName
            };

            var roleResult = await _roleManager.CreateAsync(newRole);

            if (roleResult.Succeeded)
            {
                return Ok();
            }
            return Problem(roleResult.Errors.First().Description, null, 500);
        }

        [HttpPost("User/{userEmail}/Role")]
        public async Task<IActionResult> AddUserToRole(string userEmail, [FromBody] string roleName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok();
            }
            return Problem(result.Errors.First().Description, null, 500);
        }
        private string GenerateJwt(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Issuer,
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
