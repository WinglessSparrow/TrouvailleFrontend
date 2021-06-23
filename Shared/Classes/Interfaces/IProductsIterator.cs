using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IProductIterator {
        SearchModel SearchData { get; set; }
        Task<List<ProductModel>> GetNextProductsAsync();
        Task<List<ProductModel>> GetPreviousProductsAsync();
        Task<List<ProductModel>> GetProductIndexedAsync(int index);
        Task<ProductsNumbersModel> GetProductNumbersAsync();
        int GetIndex();
    }
}
