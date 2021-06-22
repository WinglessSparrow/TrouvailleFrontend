using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class QueriedProductsRetrieverAPI : IQueriedProductsRetriever {
        private IHttpRequest _httpRequest;
        private IErrorHandler _errorHandler;
        public QueriedProductsRetrieverAPI(IHttpRequest httpRequest, IErrorHandler errorHandler) {
            _httpRequest = httpRequest;
            _errorHandler = errorHandler;
        }

        public async Task<List<ProductModel>> PostNumberProductsAsync(IEnumerable<KeyValuePair<string, string>> parameters) {
            try {
                var response = await _httpRequest.PostRequestEncodedContentAsync<string>($"{ApiPathsCentralDefinition.API_SEARCH_QUERY_COUNT}", "", parameters);

                if (response.IsSuccessStatusCode) {
                    var outputProduct = await response.Content.ReadFromJsonAsync<List<ProductModel>>();
                    return outputProduct;
                }
                _errorHandler.SetLastError(response);
            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return null;
        }

        public async Task<List<ProductModel>> PostProductsInRangeAsync(int start, int end, IEnumerable<KeyValuePair<string, string>> parameters) {
            try {
                var response = await _httpRequest.PostRequestEncodedContentAsync<string>($"{ApiPathsCentralDefinition.API_SEARCH_QUERY}/{start}/{end}", "[]", parameters);

                if (response.IsSuccessStatusCode) {
                    var outputProduct = await response.Content.ReadFromJsonAsync<List<ProductModel>>();
                    return outputProduct;
                }
                _errorHandler.SetLastError(response);
            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return null;
        }
    }
}