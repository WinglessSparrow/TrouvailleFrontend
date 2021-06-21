using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrouvailleFrontend.Shared.Models;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using System;
using System.Net.Http;
using System.Net;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class ProductsRetrieverAPI : IProductsRetriever {
        private IHttpRequest _httpRequest;
        private IErrorHandler _errorHandler;
        public ProductsRetrieverAPI(IHttpRequest httpRequest, IErrorHandler errorHandler) {
            _httpRequest = httpRequest;
            _errorHandler = errorHandler;
        }

        public async Task<List<ProductModel>> GetProductsByIdAsync(List<ShoppingCartItemModel> items) {

            List<string> _stringItems = new();
            foreach (var item in items) {
                _stringItems.Add(item.ProductId);
            }

            try {
                var response = await _httpRequest.PostRequestAsync<List<string>>(ApiPathsCentralDefinition.API_PRODUCTS_BY_ID_ARRAY, _stringItems);
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

        public async Task<ProductModel> GetProductByIdAsync(string item) {
            try {
                var response = await _httpRequest.GetRequestAsync($"{ApiPathsCentralDefinition.API_PRODUCT_BY_ID}/{item}");
                if (response.IsSuccessStatusCode) {
                    var outputProduct = await response.Content.ReadFromJsonAsync<ProductModel>();
                    return outputProduct;
                }
                _errorHandler.SetLastError(response);
            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return null;
        }

        public async Task<List<ProductModel>> GetProductsInRangeAsync(int start, int end) {
            try {
                var response = await _httpRequest.GetRequestAsync($"{ApiPathsCentralDefinition.API_PRODUCTS_IN_RANGE}/{start}/{end}");
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

        public async Task<int> GetNumberProductsAsync() {
            try {
                var response = await _httpRequest.GetRequestAsync($"{ApiPathsCentralDefinition.API_PRODUCT_COUNT}");
                if (response.IsSuccessStatusCode) {
                    int outputProduct = await response.Content.ReadFromJsonAsync<int>();
                    return outputProduct;
                }
                _errorHandler.SetLastError(response);
            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return 0;
        }
    }
}