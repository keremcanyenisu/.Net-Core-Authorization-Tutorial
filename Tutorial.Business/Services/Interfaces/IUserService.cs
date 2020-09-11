using System.Threading.Tasks;
using Tutorial.Business.Models.Users;
using Tutorial.Domain.Entities;

namespace Tutorial.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> Authenticate(string username, string password);
        Task<User> Register(string username, string password);
    }
}
