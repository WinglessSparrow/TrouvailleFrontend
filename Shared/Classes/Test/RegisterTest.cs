using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.API;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;
using System.Net;
using System;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class RegisterTest : IRegister {

        IHttpRequest _http;
        IErrorHandler _errorHandler;

        public RegisterTest(IHttpRequest http, IErrorHandler errorHandler) {
            _http = http;
            _errorHandler = errorHandler;
        }

        public async Task<bool> RegisterAsync(RegisterModel _registerData) {

            try {
                HttpResponseMessage response = await _http.PostRequestAsync<RegisterModel>("https://localhost", _registerData);
                if (response.IsSuccessStatusCode) return true;

                _errorHandler.SetLastError(response);

            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return true;
        }
    }
}