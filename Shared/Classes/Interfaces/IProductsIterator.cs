using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IProductIterator {
        Task<List<ProductModel>> GetNextProductsAsync();
        Task<List<ProductModel>> GetPreviousProductsAsync();
        Task<List<ProductModel>> GetProductIndexedAsync(int index);
        ProductsNumbersModel GetProductNumbers();
        int GetIndex();
    }
}
