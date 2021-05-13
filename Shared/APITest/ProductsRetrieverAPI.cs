using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes {
    public class ProductsRetrieverAPI : IProductsRetrieverAPI {
        private HttpClient _http;

        public ProductsRetrieverAPI(HttpClient http) {
            _http = http;
        }

        public async Task<List<ProductModel>> GetProductsByIdAsync(List<ShoppingCartItemModel> items) {

            //use this when API actually does what it should
            // var response = await _http.PostRequestAsync<List<Guid>>("", CreateListOfId(items));
            // var output = response.Content.ReadFromJsonAsync<List<ProductModel>>();
            // return await _iterator.GetNextProductsAsync();

            var allProducts = await _http.GetFromJsonAsync<List<ProductModel>>("debugData/Products.json");
            var outputProducts = new List<ProductModel>();

            foreach (ProductModel p in allProducts) {
                foreach (ShoppingCartItemModel shmp in items) {
                    if (p.ProductId == shmp.ProductId) {
                        outputProducts.Add(p);
                        break;
                    }
                }
            }

            return outputProducts;
        }

        private List<Guid> CreateListOfId(List<ShoppingCartItemModel> scItems) {

            List<Guid> ids = new();

            foreach (ShoppingCartItemModel shpm in scItems) {
                ids.Add(shpm.ProductId);
            }

            return ids;
        }
    }
}