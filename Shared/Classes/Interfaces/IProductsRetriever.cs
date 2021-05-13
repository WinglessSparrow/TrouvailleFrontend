using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IProductsRetriever {
        Task<List<ProductModel>> GetProductsByIdAsync(List<ShoppingCartItemModel> items);
        Task<ProductModel> GetProductByIdAsync(string item);
        Task<List<ProductModel>> GetProductsInRangeAsync(int start, int end);
        Task<int> GetNumberProductsAsync();
    }
}