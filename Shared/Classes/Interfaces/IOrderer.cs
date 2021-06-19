using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IOrderer {
        Task<bool> OrderAsync(OrderModel order);
    }
}