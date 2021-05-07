using TrouvailleFrontend.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace TrouvailleFrontend.Shared.Classes
{
    interface ILocalStorage
    {
        Task<T> GetStorageAsync<T>(string key);
        Task SetStorageAsync<T>(string key, T value);
        Task DeleteStorageAsync(string key);
        Task<int> LengthStorageAsync();
        //Task ClearStorageAsync();

    }
}