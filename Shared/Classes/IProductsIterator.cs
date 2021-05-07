using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes {
    interface IProductIterator {
        Task<List<Product>> GetNextProductsAsync();
        Task<List<Product>> GetPreviousProductsAsync();
        Task<List<Product>> GetProductIndexedAsync(int index);
        Task<ProductsNumbers> GetProductNumbersAsync();
    }
}
