using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace TrouvailleFrontend.Shared.Classes {
    public interface IProductsRetrieverAPI {
        public Task<List<ProductModel>> GetProductsByIdAsync(List<ShoppingCartItemModel> items);
    }
}