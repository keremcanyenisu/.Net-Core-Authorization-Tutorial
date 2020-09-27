using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Business.Helpers;
using Tutorial.Business.Models.Users;
using Tutorial.Business.Services.Interfaces;
using Tutorial.Business.Utility.Extentions;
using Tutorial.Domain.Context;
using Tutorial.Domain.Entities;

namespace Tutorial.Business.Services
{
    public class UserService : IUserService
    {
        private readonly TutorialDbContext dbContext;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, TutorialDbContext dbContext)
        {
            _appSettings = appSettings.Value;
            this.dbContext = dbContext;
        }


        public async Task<string> Authenticate(string username, string password)
        {
            var checkUser = dbContext.Users.Where(x => x.Username == username);
         
            if (checkUser != null)
            {
                var hPassword = password.GetHashValue(new SHA256CryptoServiceProvider());
                var checkPassword = dbContext.Users.Where(x => x.Password == hPassword);

                if(checkPassword != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);


                    return await Task.FromResult(tokenHandler.WriteToken(token));

                }
                else
                {
                    throw new Exception("Invalid Password");
                }

            }
            else
            {
                throw new Exception("Invalid Username");
            }    
        }

        public async Task<User> Register(string username, string password)
        {
            string hPassword = password.GetHashValue(new SHA256CryptoServiceProvider());

            User newUser = new User
            {
                Username = username,
                Password = hPassword
            };

            dbContext.Users.Add(newUser);


            await dbContext.SaveChangesAsync();
            return await Task.FromResult(newUser);
        }  
    }
}
