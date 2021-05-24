using System.Net.Http;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes.Interfaces
{
    public interface IErrorHandler
    {
        void SetLastError(HttpResponseMessage response);
        string GetErrorStringForLastError();
        string GetErrorStringIndexed();
    }
}