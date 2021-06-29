using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Functional;
using TrouvailleFrontend.Shared.Classes.Interfaces;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class ErrorHandler : IErrorHandler {

        HttpResponseMessage _lastResponse = new();

        public string GetLastErrorString() {
            return ErrorMapping.ErrorsMapped[_lastResponse.StatusCode];
        }

        public void SetLastError(HttpResponseMessage response) {
            _lastResponse = response;
        }

        public HttpStatusCode GetLastErrorCode() {
            return _lastResponse.StatusCode;
        }

        public string GetLastErrorCodeString() {
            return _lastResponse.Content.ReadAsStringAsync().Result;
        }

        public HttpResponseMessage GetLastErrorResponse() {
            return _lastResponse;
        }
    }
}