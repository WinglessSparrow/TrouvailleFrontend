using System.Collections.Generic;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IQueriedProductsRetriever {
        Task<List<ProductModel>> PostProductsInRangeAsync(int start, int end, IEnumerable<KeyValuePair<string, string>> parameters);
        Task<List<ProductModel>> PostNumberProductsAsync(IEnumerable<KeyValuePair<string, string>> parameters);
    }
}