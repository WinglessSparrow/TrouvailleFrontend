using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes {
    interface IProductIterator {
        Task<List<ProductModel>> GetNextProductsAsync();
        Task<List<ProductModel>> GetPreviousProductsAsync();
        Task<List<ProductModel>> GetProductIndexedAsync(int index);
        Task<ProductsNumbersModel> GetProductNumbersAsync();
    }
}
