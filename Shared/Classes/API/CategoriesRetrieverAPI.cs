using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class CategoriesRetrieverAPI : ICategoriesRetriever {

        private IHttpRequest _http;
        private IErrorHandler _errorHandler;
        public CategoriesRetrieverAPI(IHttpRequest http, IErrorHandler errorHandler) {
            _http = http;
            _errorHandler = errorHandler;
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync() {

            try {
                Console.WriteLine(ApiPathsCentralDefinition.API_GET_CATEGORIES);

                var response = await _http.GetRequestAsync(ApiPathsCentralDefinition.API_GET_CATEGORIES);
                if (response.IsSuccessStatusCode) {
                    var output = await response.Content.ReadFromJsonAsync<List<CategoryModel>>();
                    return output;
                }

                _errorHandler.SetLastError(response);
            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return null;
        }
    }
}