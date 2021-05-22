using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.API;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;
using System.Net;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class RegisterTest : IRegister {

        IHttpRequest _http;

        public RegisterTest(IHttpRequest http) {
            _http = http;
        }

        public async Task<bool> RegisterAsync(RegisterModel _registerData) {

            try {
                HttpResponseMessage response = await _http.PostRequestAsync<RegisterModel>("https://localhost", _registerData);
                if (response.StatusCode == HttpStatusCode.OK) return true;
                //TODO handle all possible messages
                return false;
            } catch (HttpRequestException e) {
                
                return false;
            }
        }
    }
}