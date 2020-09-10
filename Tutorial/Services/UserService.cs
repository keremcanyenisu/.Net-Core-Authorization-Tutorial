using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models.Users;
using Tutorial.Services.Interfaces;

namespace Tutorial.Services
{
    public class UserService : IUserService
    {
        public async Task<UserModel> Authenticate(string username, string password)
        {

            return await Task.FromResult(new UserModel { Username = "kerem", Password = "1234" });


        }

    }
}
