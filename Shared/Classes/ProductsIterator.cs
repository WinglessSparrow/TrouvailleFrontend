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
        private int _index = 0;
        private int _numberProductsPerIteration = 10;
        public ProductsIterator(HttpClient http)
        {
            Task.Run(async () =>
            {
                _products = await http.GetFromJsonAsync<Product[]>("debugData/Products.json");
            });

            Console.WriteLine("Hi, I'm yout iterator for this night");
        }

        public List<Product> GetNextProducts()
        {
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

        public List<Product> GetPreviousProducts()
        {
            _index--;
            if (_index <= 0)
            {
                _index = 1;
                return null;
            }

            int offset = _index * _numberProductsPerIteration;
            int limit = offset + _numberProductsPerIteration;

            return CopyArrayToList(offset, limit);
        }

        public List<Product> GetProductIndexed(int index)
        {
            return null;
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