using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pass_It_Out_Angular_WebAPI.Models;
using Pass_It_Out_Angular_WebAPI.Services.UserService;
using Pass_It_Out_Angular_WebAPI.View_Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace Pass_It_Out_Angular_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser userservice;
        public IConfiguration configuration;
        public UserController(IUser userservice, IConfiguration config) 
        {
            this.configuration = config;
            this.userservice = userservice;
        }

        [HttpPost("Registration")]
        public bool Registration(UserVM userVM)
        {
            User newuser = new User();
            newuser.UserId = userVM.UserId;
            newuser.Password = GetHashedPassword(userVM.Password);
            newuser.Email = userVM.Email;
            newuser.FirstName = userVM.FirstName;   
            newuser.LastName = userVM.LastName;
            newuser.Location = userVM.Location;
            bool flag=userservice.Registration(newuser);  
            return flag;
        }

        [NonAction]
        public string GetHashedPassword(string password)
        {
            string Hashcode;
            using (SHA256 sha256Hash=SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder stringBuilder= new StringBuilder();
                for(int i=0;i<bytes.Length;i++)
                {
                    stringBuilder.Append(bytes[i].ToString("X2"));
                }
                Hashcode = stringBuilder.ToString();
            }
            return Hashcode;
        }



        [HttpPost("Login")]
        public IActionResult Login(UserLoginVM userVM)
        {
            IActionResult response = Unauthorized();

            User newuser = new User();
            newuser.UserId= userVM.UserId;
            newuser.Password =GetHashedPassword(userVM.Password);
            User ExistingUser = userservice.IsUserExist(newuser);

            if (userVM != null && newuser.UserId == ExistingUser.UserId && newuser.Password == ExistingUser.Password)
            {
                var issuer = configuration["Jwt:Issuer"];
                var audience = configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                );

                var subject = new ClaimsIdentity(new[]
                {
                        new Claim("UserId", ExistingUser.UserId),
                        new Claim("Password", ExistingUser.Password),
                    });

                var expires = DateTime.UtcNow.AddMinutes(10);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                return Ok(jwtToken);

            }
            return response;
        }
    }
}
