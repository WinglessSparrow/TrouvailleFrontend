using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;

namespace TrouvailleFrontend.Shared.Classes
{
    interface IProductIterator
    {
        List<Product> GetNextProducts();
        List<Product> GetPreviousProducts();
        List<Product> GetProductIndexed(int index);
    }
}
