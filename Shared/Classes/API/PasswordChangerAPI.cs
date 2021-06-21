using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using TrouvailleFrontend.Shared.Models;
using TrouvailleFrontend.Shared.Models.Auth;
using TrouvailleFrontend.Shared.Classes.Interfaces;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class PasswordChangerAPI : IPasswordChanger {

        private IHttpRequest _requester;
        private IErrorHandler _errorHandler;
        public PasswordChangerAPI(IHttpRequest requester, IErrorHandler errorHandler) {
            _requester = requester;
            _errorHandler = errorHandler;
        }
        public async Task<bool> ChangePasswordAsync(ResetPasswordModel newPassword) {
            try {
                HttpResponseMessage response = await _requester.PostRequestAsync<ResetPasswordModel>($"{ApiPathsCentralDefinition.API_RESET_PASSWORD}", newPassword);
                if (response.IsSuccessStatusCode) return true;

                _errorHandler.SetLastError(response);

            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return false;
        }
    }
}