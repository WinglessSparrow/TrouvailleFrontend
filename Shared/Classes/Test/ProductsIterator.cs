using System;
using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class ProductsIterator : IProductIterator {
        private ProductModel[] _products;
        private int _index = 0;
        private int _numberProductsPerIteration = 7;
        private HttpClient _http;

        public ProductsIterator(HttpClient http) {
            _http = http;
        }

        public int GetIndex() {
            return _index;
        }

        public async Task<List<ProductModel>> GetNextProductsAsync() {
            _products = await _http.GetFromJsonAsync<ProductModel[]>("debugData/Products.json");

            _index++;
            if (_index * _numberProductsPerIteration > _products.Length) return null;

            int offset = _index * _numberProductsPerIteration;
            int limit = offset + _numberProductsPerIteration;

            return CopyArrayToList(offset, limit);
        }

        public async Task<List<ProductModel>> GetPreviousProductsAsync() {
            _products = await _http.GetFromJsonAsync<ProductModel[]>("debugData/Products.json");

            _index--;
            if (_index < 0) {
                _index = -1;
                return null;
            }

            Console.WriteLine(_index);

            int offset = _index * _numberProductsPerIteration;
            int limit = offset + _numberProductsPerIteration;

            return CopyArrayToList(offset, limit);
        }
        public async Task<List<ProductModel>> GetProductIndexedAsync(int index) {
            _products = await _http.GetFromJsonAsync<ProductModel[]>("debugData/Products.json");

            if (index < 0 || index >= _products.Length) return null;
            _index = index;

            int offset = _index * _numberProductsPerIteration;
            int limit = offset + _numberProductsPerIteration;

            return CopyArrayToList(offset, limit);
        }

        public async Task<ProductsNumbersModel> GetProductNumbersAsync() {
            _products = await _http.GetFromJsonAsync<ProductModel[]>("debugData/Products.json");
            return new ProductsNumbersModel() { NumberOfProduct = _products.Length, NumberProductsPerIteration = _numberProductsPerIteration };
        }

        public void InitIterator() {
            //here be code
        }

        private List<ProductModel> CopyArrayToList(int from, int to) {
            List<ProductModel> products = new List<ProductModel>();

            for (int i = from; i < to; i++) {
                if (!(i >= _products.Length)) {
                    products.Add(_products[i]);
                } else {
                    break;
                }
            }

            return products;
        }
    }
}