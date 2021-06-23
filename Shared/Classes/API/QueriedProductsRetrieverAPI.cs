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

        public async Task<int> PostNumberProductsAsync(SearchModel searchModel) {
            try {

                var categoryIds = searchModel.GetCategoryIds();

                var response = await _httpRequest.PostRequestEncodedContentAsync<List<string>>($"{ApiPathsCentralDefinition.API_SEARCH_QUERY_COUNT}", categoryIds, searchModel.Parameteres);

                if (response.IsSuccessStatusCode) {
                    var outputProduct = await response.Content.ReadFromJsonAsync<int>();
                    return outputProduct;
                }
                _errorHandler.SetLastError(response);
            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return 0;
        }

        public async Task<List<ProductModel>> PostProductsInRangeAsync(int start, int end, SearchModel searchModel) {
            try {
                var categoryIds = searchModel.GetCategoryIds();

                var response = await _httpRequest.PostRequestEncodedContentAsync<List<string>>($"{ApiPathsCentralDefinition.API_SEARCH_QUERY}/{start}/{end}", categoryIds, searchModel.Parameteres);

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