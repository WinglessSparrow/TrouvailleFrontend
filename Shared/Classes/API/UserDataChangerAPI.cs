using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class UserDataChangerAPI : IUserDataChanger {
        IErrorHandler _errorHandler;
        IHttpRequest _httpRequest;

        public UserDataChangerAPI(IErrorHandler errorHandler, IHttpRequest httpRequest) {
            _errorHandler = errorHandler;
            _httpRequest = httpRequest;
        }

        public async Task<bool> changeUserDataAsync(UserModel userData) {
        try {
                var response = await _httpRequest.PutRequestAsync<UserModel>(ApiPathsCentralDefinition.API_CHANGE_USER, userData);
                if (response.IsSuccessStatusCode) return true;

                _errorHandler.SetLastError(response);

            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return false;
        }
    }
}