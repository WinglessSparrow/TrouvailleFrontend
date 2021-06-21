using System.Collections.Generic;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Interfaces
{
    public interface IOrderRetriever
    {
        Task<List<SmallOrderModel>> GetSlimOrdersAsync();
        Task<SmallOrderModel> GetSlimOrderAsync();
    }
}