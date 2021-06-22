using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IProductIterator {

        string SearchWord { get; set; }
        bool Ascending { get; set; }

        Task<List<ProductModel>> GetNextProductsAsync();
        Task<List<ProductModel>> GetPreviousProductsAsync();
        Task<List<ProductModel>> GetProductIndexedAsync(int index);
        Task<ProductsNumbersModel> GetProductNumbersAsync();
        int GetIndex();
    }
}
