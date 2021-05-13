using System.Collections.Generic;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class ProductsIterator : IProductIterator {

        private IProductsRetriever _retriever;
        private int _index;
        private ProductsNumbersModel _productsNumber = new();

        public ProductsIterator(IProductsRetriever retriever) {
            _retriever = retriever;
            _productsNumber.NumberProductsPerIteration = 8;
            _productsNumber.NumberOfProduct = _retriever.GetNumberProducts();
        }

        public int GetIndex() {
            return _index;
        }

        public async Task<List<ProductModel>> GetNextProductsAsync() {
            _index++;
            if (_index * _productsNumber.NumberProductsPerIteration > _productsNumber.NumberOfProduct) return null;

            int offset = _index * _productsNumber.NumberProductsPerIteration;
            int limit = offset + _productsNumber.NumberProductsPerIteration;

            return await _retriever.GetProductsInRange(offset, limit);
        }

        public async Task<List<ProductModel>> GetPreviousProductsAsync() {
            _index--;
            if (_index < 0) {
                _index = -1;
                return null;
            }

            int offset = _index * _productsNumber.NumberProductsPerIteration;
            int limit = offset + _productsNumber.NumberProductsPerIteration;

            return await _retriever.GetProductsInRange(offset, limit);
        }

        public async Task<List<ProductModel>> GetProductIndexedAsync(int index) {
            if (index < 0 || index >= _productsNumber.NumberOfProduct) return null;
            _index = index;

            int offset = _index * _productsNumber.NumberProductsPerIteration;
            int limit = offset + _productsNumber.NumberProductsPerIteration;

            return await _retriever.GetProductsInRange(offset, limit);
        }

        public ProductsNumbersModel GetProductNumbers() {
            return _productsNumber;
        }
    }
}