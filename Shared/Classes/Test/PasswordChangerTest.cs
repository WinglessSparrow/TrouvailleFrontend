using System.Threading;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models.Auth;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class PasswordChangerTest : IPasswordChanger {
        public async Task<bool> ChangePasswordAsync(ResetPasswordModel newPassword) {

            await Task.Run(() => Thread.Sleep(400));

            return true;
        }
    }
}