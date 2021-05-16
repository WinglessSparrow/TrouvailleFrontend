using System;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class LoginTest : ILogin {
        private ILocalStorage _storage;

        public LoginTest(ILocalStorage storage) {
            _storage = storage;
        }

        public async Task<bool> loginAsync(LoginModel loginData) {

            TokenModel token_test = new TokenModel() { AuthToken = "TokenValue", expireDate = DateTime.Today.AddDays(5) };
            await _storage.SetStorageAsync<TokenModel>("authToken", token_test);

            return true;
        }
    }
}