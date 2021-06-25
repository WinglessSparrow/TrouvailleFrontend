using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using TrouvailleFrontend.Shared.Models;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using System.Collections.Generic;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class HttpRequest : IHttpRequest {
        private HttpClient _http;
        private ILocalStorage _localStorage;

        public HttpRequest(HttpClient http, ILocalStorage localStorage) {
            _http = http;
            _localStorage = localStorage;
        }

        public async Task<HttpResponseMessage> GetRequestAsync(string path) {
            HttpResponseMessage response;

            TokenModel token = await _localStorage.GetStorageAsync<TokenModel>("authToken");

            var request = new HttpRequestMessage(HttpMethod.Get, path);

            var authHeader = new AuthenticationHeaderValue("Bearer", token.AuthToken);
            request.Headers.Authorization = authHeader;

            Console.WriteLine($"Request: {path}");

            response = await _http.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> PostRequestAsync<T>(string path, T postBody) {
            HttpResponseMessage response;

            TokenModel token = await _localStorage.GetStorageAsync<TokenModel>("authToken");

            var request = new HttpRequestMessage(HttpMethod.Post, path);

            var options = new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(postBody, options), Encoding.UTF8, "application/json");
            request.Content = stringContent;

            var authHeader = new AuthenticationHeaderValue("Bearer", token.AuthToken);
            request.Headers.Authorization = authHeader;

            response = await _http.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> PostRequestEncodedContentAsync<T>(string path, T postBody, IEnumerable<KeyValuePair<string, string>> parameters) {
            HttpResponseMessage response;

            TokenModel token = await _localStorage.GetStorageAsync<TokenModel>("authToken");

            path = AppendEncodedParameters(path, parameters);

            var encodedParameters = new FormUrlEncodedContent(parameters);

            var request = new HttpRequestMessage(HttpMethod.Post, path);

            var options = new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(postBody, options), Encoding.UTF8, "application/json");
            request.Content = stringContent;

            var authHeader = new AuthenticationHeaderValue("Bearer", token.AuthToken);
            request.Headers.Authorization = authHeader;

            response = await _http.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> PutRequestAsync<T>(string path, T putBody) {
            HttpResponseMessage response;

            TokenModel token = await _localStorage.GetStorageAsync<TokenModel>("authToken");

            var request = new HttpRequestMessage(HttpMethod.Put, path);

            var options = new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(putBody, options), Encoding.UTF8, "application/json");
            request.Content = stringContent;

            var authHeader = new AuthenticationHeaderValue("Bearer", token.AuthToken);
            request.Headers.Authorization = authHeader;

            response = await _http.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> PutRequestEncodedContentAsync<T>(string path, T postBody, IEnumerable<KeyValuePair<string, string>> parameters) {
            HttpResponseMessage response;

            TokenModel token = await _localStorage.GetStorageAsync<TokenModel>("authToken");

            path = AppendEncodedParameters(path, parameters);

            var request = new HttpRequestMessage(HttpMethod.Put, path);

            var options = new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(postBody, options), Encoding.UTF8, "application/json");
            request.Content = stringContent;

            var authHeader = new AuthenticationHeaderValue("Bearer", token.AuthToken);
            request.Headers.Authorization = authHeader;

            response = await _http.SendAsync(request);

            return response;
        }

        private string AppendEncodedParameters(string path, IEnumerable<KeyValuePair<string, string>> parameters) {
            var builder = new StringBuilder(path);
            builder.Append("?");
            foreach (var pair in parameters) {
                builder.Append(pair.Key);
                builder.Append("=");
                builder.Append(pair.Value);
                builder.Append("&");
            }
            builder.Remove(builder.Length - 1, 1);

            return builder.ToString();
        }
    }
}

