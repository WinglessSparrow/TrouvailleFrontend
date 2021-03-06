using System.Collections.Generic;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Interfaces {
    public interface IUserDataChanger {
        Task<bool> changeUserDataAsync(UserModel userData);
    }
}