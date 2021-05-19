using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;
using TrouvailleFrontend.Shared.Classes;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class LoginAPI : ILogin {

        private IHttpRequest _requester;
        private ILocalStorage _storage;

        public LoginAPI(IHttpRequest requester, ILocalStorage storage) {
            _requester = requester;
            _storage = storage;
        }

        public async Task<bool> LoginAsync(LoginModel loginData) {
            var responseLogin = await _requester.PostRequestAsync<LoginModel>(ApiPathsCentralDefinition.API_LOGIN, loginData);
            if (responseLogin.StatusCode == HttpStatusCode.OK) {
                AuthResponseMessageModel message = await responseLogin.Content.ReadFromJsonAsync<AuthResponseMessageModel>();

                if (message.isSuccess) {
                    TokenModel token = new TokenModel() { AuthToken = message.message, expireDate = message.expireDate };
                    await _storage.SetStorageAsync<TokenModel>("authToken", token);
                    return true;
                }
            }

            return false;
        }
    }
}