using TrouvailleFrontend.Shared.Models;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface ILogin {
        Task<bool> loginAsync(LoginModel loginData);
    }
}