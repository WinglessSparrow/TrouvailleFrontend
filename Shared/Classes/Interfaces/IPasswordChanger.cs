using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Models.Auth;

namespace TrouvailleFrontend.Shared.Classes.Interfaces
{
    public interface IPasswordChanger
    {
        Task<bool> ChangePasswordAsync(ResetPasswordModel newPassword);
    }
}