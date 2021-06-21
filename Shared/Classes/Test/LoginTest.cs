using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class LoginTest : ILogin {
        private ILocalStorage _storage;
        private IErrorHandler _error;

        public LoginTest(ILocalStorage storage, IErrorHandler error) {
            _storage = storage;
            _error = error;
        }

        public async Task<bool> LoginAsync(LoginModel loginData) {

            await Task.Run(() => Thread.Sleep(400));

            TokenModel token_test = new TokenModel() { AuthToken = "TokenValue", expireDate = DateTime.Today.AddDays(5) };
            await _storage.SetStorageAsync<TokenModel>("authToken", token_test);

            _error.SetLastError(new System.Net.Http.HttpResponseMessage(HttpStatusCode.Unauthorized));

            return true;
        }
    }
}