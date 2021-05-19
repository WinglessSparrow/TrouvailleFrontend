using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Interfaces
{
    public interface IRegister
    {
        Task<bool> RegisterAsync(RegisterModel _registerData);
    }
}