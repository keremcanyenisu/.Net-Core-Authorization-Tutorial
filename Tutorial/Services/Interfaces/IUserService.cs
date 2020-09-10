using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Models.Users;

namespace Tutorial.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> Authenticate(string username, string password);
       
    }
}
