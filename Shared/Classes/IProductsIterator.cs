using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes
{
    interface IProductIterator
    {
        Task<List<Product>> GetNextProductsAsync();
        List<Product> GetPreviousProducts();
        List<Product> GetProductIndexed(int index);
    }
}
