using System;
using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes
{
    public class ProductsIterator : IProductIterator
    {
        private Product[] _products;
        private int _index = -1;
        private int _numberProductsPerIteration = 5;
        private HttpClient _http;
        public ProductsIterator(HttpClient http)
        {
            _http = http;
            Console.WriteLine("Hi, I'm yout iterator for this night");
        }

        public async Task<List<Product>> GetNextProductsAsync()
        {
            _products = await _http.GetFromJsonAsync<Product[]>("debugData/Products.json");

            _index++;
            if (_index * +_numberProductsPerIteration >= _products.Length)
            {
                _index--;
                return null;
            }

            int offset = _index * _numberProductsPerIteration;
            int limit = offset + _numberProductsPerIteration;

            return CopyArrayToList(offset, limit);
        }

        public async Task<List<Product>> GetPreviousProductsAsync()
        {
            _products = await _http.GetFromJsonAsync<Product[]>("debugData/Products.json");

            _index--;
            if (_index < 0)
            {
                _index = 0;
                return null;
            }

            int offset = _index * _numberProductsPerIteration;
            int limit = offset + _numberProductsPerIteration;

            return CopyArrayToList(offset, limit);
        }

        public async Task<List<Product>> GetProductIndexedAsync(int index)
        {
            _products = await _http.GetFromJsonAsync<Product[]>("debugData/Products.json");

            if (index < 0 || index >= _products.Length)
            {
                return null;
            }

            int offset = _index * _numberProductsPerIteration;
            int limit = offset + _numberProductsPerIteration;

            return CopyArrayToList(offset, limit);
        }

        private List<Product> CopyArrayToList(int from, int to)
        {
            List<Product> products = new List<Product>();

            for (int i = from; i < to; i++)
            {
                if (!(i >= _products.Length))
                {
                    products.Add(_products[i]);
                }
                else
                {
                    break;
                }
            }

            return products;
        }
    }
}