using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class UserDataChangerTest : IUserDataChanger {
        public Task<bool> changeAddressAsync(UserModel userData) {
            throw new System.NotImplementedException();
        }

        public async Task<bool> changeUserDataAsync(UserModel userData) {
            return false;
        }
    }
}