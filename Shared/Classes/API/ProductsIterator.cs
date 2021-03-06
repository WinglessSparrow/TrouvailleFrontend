using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class ProductsIterator : IProductIterator {

        private IProductsRetriever _retriever;
        private IQueriedProductsRetriever _queriedRetriever;
        private int _index;
        private ProductsNumbersModel _productsNumber = new();

        private Dictionary<string, string> _parameters = new Dictionary<string, string>(){
            {"searchWord", ""},
            {"asc", "false"},
            {"orderBy", "Price"},
            {"onlyActive", "true"}
        };

        public SearchModel SearchData { get; set; }

        public ProductsIterator(IProductsRetriever retriever, IQueriedProductsRetriever queriedRetriever) {
            _retriever = retriever;
            _queriedRetriever = queriedRetriever;

            _productsNumber.NumberProductsPerIteration = 8;

            Task.Run(async () => {
                _productsNumber.NumberOfProduct = await _queriedRetriever.PostNumberProductsAsync(SearchData);
            });
        }

        public int GetIndex() {
            return _index;
        }

        public async Task<List<ProductModel>> GetNextProductsAsync() {
            _index++;
            if (_index * _productsNumber.NumberProductsPerIteration > _productsNumber.NumberOfProduct) return null;

            int offset = _index * _productsNumber.NumberProductsPerIteration;
            int limit = offset + _productsNumber.NumberProductsPerIteration;

            return await _queriedRetriever.PostProductsInRangeAsync(offset, limit, SearchData);
        }

        public async Task<List<ProductModel>> GetPreviousProductsAsync() {
            _index--;
            if (_index < 0) {
                _index = -1;
                return null;
            }

            int offset = _index * _productsNumber.NumberProductsPerIteration;
            int limit = offset + _productsNumber.NumberProductsPerIteration;

            return await _queriedRetriever.PostProductsInRangeAsync(offset, limit, SearchData);
        }

        public async Task<List<ProductModel>> GetProductIndexedAsync(int index) {

            if (index < 0 || index > _productsNumber.NumberOfProduct) return null;
            _index = index;

            int offset = _index * _productsNumber.NumberProductsPerIteration;
            int limit = offset + _productsNumber.NumberProductsPerIteration;

            return await _queriedRetriever.PostProductsInRangeAsync(offset, limit, SearchData);
        }

        public async Task<ProductsNumbersModel> GetProductNumbersAsync() {
            _productsNumber.NumberOfProduct = await _queriedRetriever.PostNumberProductsAsync(SearchData);
            return _productsNumber;
        }
    }
}