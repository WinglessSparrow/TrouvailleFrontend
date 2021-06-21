using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IErrorHandler {
        void SetLastError(HttpResponseMessage response);
        string GetLastErrorString();
        HttpStatusCode GetLastErrorCode();
        HttpResponseMessage GetLastErrorResponse();
    }
}