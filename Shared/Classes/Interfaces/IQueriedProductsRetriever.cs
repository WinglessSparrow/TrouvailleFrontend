using System.Collections.Generic;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IQueriedProductsRetriever {
        Task<List<ProductModel>> PostProductsInRangeAsync(int start, int end, SearchModel searchModel);
        Task<int> PostNumberProductsAsync(SearchModel searchModel);
    }
}