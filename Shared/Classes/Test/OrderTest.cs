using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class OrderTest : IOrder {
        public async Task<bool> OrderAsync(OrderModel order) {
            return true;
        }
    }
}