using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes {
    public class ProductsRetriever : IProductsRetriever {
        private HttpClient _http;

        public ProductsRetriever(HttpClient http) {
            _http = http;
        }

        public async Task<List<ProductModel>> GetProductsByIdAsync(List<ShoppingCartItemModel> items) {

            //use this when API actually does what it should
            // var response = await _http.PostRequestAsync<List<int>>("", CreateListOfId(items));
            // var output = response.Content.ReadFromJsonAsync<List<ProductModel>>();
            // return await _iterator.GetNextProductsAsync();

            List<ProductModel> allProducts = await _http.GetFromJsonAsync<List<ProductModel>>("debugData/Products.json");
            List<ProductModel> outputProducts = new();

            foreach (ProductModel p in allProducts) {

                Console.WriteLine("Tax: " + p.Vat);

                foreach (ShoppingCartItemModel shmp in items) {
                    if (p.Pid == shmp.ProductId) {
                        outputProducts.Add(p);
                        break;
                    }
                }
            }

            return outputProducts;
        }

        private List<int> CreateListOfId(List<ShoppingCartItemModel> scItems) {

            List<int> ids = new();

            foreach (ShoppingCartItemModel shpm in scItems) {
                ids.Add(shpm.ProductId);
            }

            return ids;
        }
    }
}