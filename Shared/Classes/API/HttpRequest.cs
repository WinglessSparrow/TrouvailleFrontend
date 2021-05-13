using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using TrouvailleFrontend.Shared.Models;
using TrouvailleFrontend.Shared.Classes.Interfaces;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class HttpRequest : IHttpRequest {
        private HttpClient _http;
        private ILocalStorage _localStorage;

        public HttpRequest(HttpClient http, ILocalStorage localStorage) {
            _http = http;
            _localStorage = localStorage;
        }


        public async Task<HttpResponseMessage> GetRequestAsync(string path){
            HttpResponseMessage response; 
            
            TokenModel token = await _localStorage.GetStorageAsync<TokenModel>("authToken");

            var request = new HttpRequestMessage(HttpMethod.Get, path);
            var authHeader = new AuthenticationHeaderValue("Bearer", token.AuthToken);
            request.Headers.Authorization = authHeader;
            
            response = await _http.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> PostRequestAsync<T>(string path, T postBody){
            HttpResponseMessage response; 
            
            TokenModel token = await _localStorage.GetStorageAsync<TokenModel>("authToken");

            var request = new HttpRequestMessage(HttpMethod.Post, path);
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(postBody), Encoding.UTF8, "application/json");
            request.Content = stringContent;
            var authHeader = new AuthenticationHeaderValue("Bearer", token.AuthToken);
            request.Headers.Authorization = authHeader;
            
            response = await _http.SendAsync(request);

            return response;
        }
    }
}

