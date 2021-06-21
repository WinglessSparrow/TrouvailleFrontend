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
        private IErrorHandler _errorHandler;

        public LoginAPI(IHttpRequest requester, ILocalStorage storage, IErrorHandler errorHandler) {
            _requester = requester;
            _storage = storage;
            _errorHandler = errorHandler;
        }

        public async Task<bool> LoginAsync(LoginModel loginData) {
            try {
                HttpResponseMessage responseLogin = await _requester.PostRequestAsync<LoginModel>(ApiPathsCentralDefinition.API_LOGIN, loginData);
                if (responseLogin.IsSuccessStatusCode) {
                    AuthResponseMessageModel message = await responseLogin.Content.ReadFromJsonAsync<AuthResponseMessageModel>();
                    if (message.isSuccess) {
                        TokenModel token = new TokenModel() { AuthToken = message.message, expireDate = message.expireDate };
                        await _storage.SetStorageAsync<TokenModel>("authToken", token);
                        return true;
                    }
                }

                _errorHandler.SetLastError(responseLogin);

            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return false;
        }
    }
}