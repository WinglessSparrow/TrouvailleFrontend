using System.Net.Http;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IHttpRequest {
        Task<HttpResponseMessage> GetRequestAsync(string path);
        Task<HttpResponseMessage> PostRequestAsync<T>(string path, T postBody);
        Task<HttpResponseMessage> PutRequestAsync<T>(string path, T putBody);
    }
}