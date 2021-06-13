using System.Collections.Generic;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IUserDataHandler {
        void changeAddressAsync(UserModel userData);
        void changeUserDataAsync(UserModel userData);
        Task<List<OrderModel>> getOrderHistoryAsync();
    }
}