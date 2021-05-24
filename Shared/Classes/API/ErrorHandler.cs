using System.Net.Http;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Functional;
using TrouvailleFrontend.Shared.Classes.Interfaces;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class ErrorHandler : IErrorHandler {

        HttpResponseMessage _lastResponse;

        public string GetErrorStringForLastError() {
            return ErrorMapping.ErrorsMapped[_lastResponse.StatusCode];
        }

        public string GetErrorStringIndexed() {
            throw new System.NotImplementedException();
        }

        public void SetLastError(HttpResponseMessage response) {
            _lastResponse = response;
        }
    }
}