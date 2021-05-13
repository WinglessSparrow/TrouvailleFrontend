using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrouvailleFrontend.Shared.Models;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using System;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class ProductsRetrieverAPI : IProductsRetriever {
        private IHttpRequest _httpRequest;

        public ProductsRetrieverAPI(IHttpRequest httpRequest) {
            _httpRequest = httpRequest;
        }

        public async Task<List<ProductModel>> GetProductsByIdAsync(List<ShoppingCartItemModel> items) {

            List<ProductModel> outputProducts;

            List<string> _stringItems = new();
            foreach (var item in items) {
                _stringItems.Add(item.ProductId);
            }

            var response = await _httpRequest.PostRequestAsync<List<string>>(ApiPathsCentralDefinition.API_PRODUCTS_BY_ID_ARRAY, _stringItems);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            outputProducts = await response.Content.ReadFromJsonAsync<List<ProductModel>>();

            //use this when API actually does what it should
            // var response = await _http.PostRequestAsync<List<Guid>>("", CreateListOfId(items));
            // var output = response.Content.ReadFromJsonAsync<List<ProductModel>>();
            // return await _iterator.GetNextProductsAsync();

            return outputProducts;
        }

        public async Task<ProductModel> GetProductByIdAsync(string item) {
            ProductModel outputProduct;

            var response = await _httpRequest.GetRequestAsync($"{ApiPathsCentralDefinition.API_PRODUCT_BY_ID}/{item}");
            outputProduct = await response.Content.ReadFromJsonAsync<ProductModel>();

            return outputProduct;
        }

        public async Task<List<ProductModel>> GetProductsInRangeAsync(int start, int end) {
            List<ProductModel> outputProducts;

            var response = await _httpRequest.GetRequestAsync($"{ApiPathsCentralDefinition.API_PRODUCTS_IN_RANGE}/{start}/{end}");
            //TODO check for 404, ...
            //errorHandler.Handle404
            outputProducts = await response.Content.ReadFromJsonAsync<List<ProductModel>>();

            return outputProducts;
        }

        public async Task<int> GetNumberProductsAsync() {
            int outputProduct;

            var response = await _httpRequest.GetRequestAsync($"{ApiPathsCentralDefinition.API_PRODUCT_COUNT}");
            outputProduct = await response.Content.ReadFromJsonAsync<int>();

            return outputProduct;
        }
    }
}