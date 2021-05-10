using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes {
    public class ProductsRetriever : IProductsRetriever {

        private IProductIterator _iterator;

        public ProductsRetriever(IProductIterator iterator) {
            _iterator = iterator;
        }

        public async Task<List<ProductModel>> GetProductsByIdAsync(List<ShoppingCartItemModel> items) {

            //use this when API actually does what it should
            // var response = await _http.PostRequestAsync<List<int>>("", CreateListOfId(items));
            // var output = response.Content.ReadFromJsonAsync<List<ProductModel>>();
            // return await output;

            foreach (ShoppingCartItemModel shpm in items) {
                Console.WriteLine($"{shpm.Cardinality} + {shpm.ProductId};");
            }

            return await _iterator.GetNextProductsAsync();
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