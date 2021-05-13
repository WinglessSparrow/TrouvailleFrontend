using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrouvailleFrontend.Shared.Models;
using TrouvailleFrontend.Shared.Classes.Interfaces;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class ProductsRetriever : IProductsRetriever {
        private HttpClient _http;

        public ProductsRetriever(HttpClient http) {
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
                    if (p.ProductId.Equals(shmp.ProductId)) {
                        outputProducts.Add(p);
                        break;
                    }
                }
            }

            return outputProducts;
        }

        public async Task<ProductModel> GetProductByIdAsync(string item) {

            var allProducts = await _http.GetFromJsonAsync<List<ProductModel>>("debugData/Products.json");
            ProductModel outputProduct = new();

            foreach (ProductModel p in allProducts) {
                if (p.ProductId.Equals(item)) {
                    outputProduct = p;
                    break;
                }
            }

            return outputProduct;
        }

        private List<string> CreateListOfId(List<ShoppingCartItemModel> scItems) {

            List<string> ids = new();

            foreach (ShoppingCartItemModel shpm in scItems) {
                ids.Add(shpm.ProductId);
            }

            return ids;
        }

        public Task<List<ProductModel>> GetProductsInRange(int start, int end) {
            throw new NotImplementedException();
        }

        public int GetNumberProducts() {
            return 0;
        }

        public Task<int> GetNumberProductsAsync() {
            throw new NotImplementedException();
        }
    }
}