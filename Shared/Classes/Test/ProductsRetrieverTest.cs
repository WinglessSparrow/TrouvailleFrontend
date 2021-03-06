using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrouvailleFrontend.Shared.Models;
using TrouvailleFrontend.Shared.Classes.Interfaces;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class ProductsRetrieverTest : IProductsRetriever {
        private HttpClient _http;

        public ProductsRetrieverTest(HttpClient http) {
            _http = http;
        }

        public async Task<List<ProductModel>> GetProductsByIdAsync(List<ShoppingCartItemModel> items) {
            
            var allProducts = await _http.GetFromJsonAsync<List<ProductModel>>("debugData/Products.json");
            var outputProducts = new List<ProductModel>();

            foreach (ShoppingCartItemModel shmp in items) {
                foreach (ProductModel p in allProducts) {
                    if (shmp.ProductId.Equals(p.ProductId)) {
                        outputProducts.Add(p);
                        break;
                    }
                }
            }

            return outputProducts;
        }

        public async Task<ProductModel> GetProductByIdAsync(string item) {

            var allProducts = await _http.GetFromJsonAsync<List<ProductModel>>("debugData/Products.json");
            ProductModel outputProduct = null;

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

        public Task<List<ProductModel>> GetProductsInRangeAsync(int start, int end) {
            throw new NotImplementedException();
        }

        public Task<int> GetNumberProductsAsync() {
            throw new NotImplementedException();
        }
    }
}