using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface ILoginDataChanger {
        void changePasswordAsync(LoginModel loginData);
        void changeEmailAsync(LoginModel loginData);
    }
}