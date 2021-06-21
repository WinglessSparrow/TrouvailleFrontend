using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class RegisterAPI : IRegister {

        private IHttpRequest _requester;
        private IErrorHandler _errorHandler;

        public RegisterAPI(IHttpRequest requester, IErrorHandler errorHandler) {
            _requester = requester;
            _errorHandler = errorHandler;
        }

        public async Task<bool> RegisterAsync(RegisterModel _registerData) {

            try {
                var response = await _requester.PostRequestAsync<RegisterModel>(ApiPathsCentralDefinition.API_REGISTER, _registerData);
                if (response.IsSuccessStatusCode) return true;

                _errorHandler.SetLastError(response);
            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return false;
        }
    }
}