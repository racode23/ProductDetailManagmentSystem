﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductDetailManagmentSystem.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthenticateController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel  model) { 
        
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password)) {
                
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim> {
                     new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

                 };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {

                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration =token.ValidTo

                }
                
                );;;
                    
            }

            return Unauthorized();

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model) { 
        
            var userExist =await _userManager.FindByNameAsync(model.UserName);
            if (userExist!=null) {
                return StatusCode(StatusCodes.Status500InternalServerError,new Response {Status="Error",Message="User Alredy Exsist!"});
            
            }
            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,

            };

            var result= await _userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded) {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation faild!!please  check user details and try again!" });

            };

            return Ok(new Response {Status="Success",Message="User Created Successfully!" });
        
        }
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model) { 
         var  userExist = await _userManager.FindByNameAsync (model.UserName);
            if (userExist!=null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User alredy Exsist!" });
            }
            IdentityUser user = new() { 
              Email= model.Email,
              SecurityStamp = Guid.NewGuid().ToString(),
              UserName = model.UserName,
            
            };
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin)) {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            }
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user,UserRoles.Admin);
            }
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return Ok(new Response {Status="Success",Message="User created successfully!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSiningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(

                  issuer:_configuration["JWT:ValidIssuer"],
                  audience: _configuration["JWT:ValidAudience"],
                  expires: DateTime.Now.AddHours(1),
                  claims:authClaims,
                  signingCredentials:new SigningCredentials(authSiningKey,SecurityAlgorithms.HmacSha256)


                ) ;
            return token ;
        }
    }
}
