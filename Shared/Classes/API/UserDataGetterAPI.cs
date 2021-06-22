using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class UserDataGetterAPI : IUserDataGetter {

        IErrorHandler _errorHandler;
        IHttpRequest _httpRequest;

        public UserDataGetterAPI(IErrorHandler errorHandler, IHttpRequest httpRequest) {
            _errorHandler = errorHandler;
            _httpRequest = httpRequest;
        }

        public async Task<UserModel> getUserDataAsync() {

            try {
                var response = await _httpRequest.GetRequestAsync(ApiPathsCentralDefinition.API_GET_USER);
                if (response.IsSuccessStatusCode) {
                    var user = await response.Content.ReadFromJsonAsync<UserModel>();
                    return user;
                }

                _errorHandler.SetLastError(response);

            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return null;
        }
    }
}