using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Classes {
    public interface ILocalStorage {
        Task<T> GetStorageAsync<T>(string key);
        Task SetStorageAsync<T>(string key, T value);
        Task RemoveStorageAsync(string key);
        Task<int> LengthStorageAsync();
    }
}