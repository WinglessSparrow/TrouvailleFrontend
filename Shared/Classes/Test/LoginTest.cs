using System;
using System.Net.Http;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class LoginTest : ILogin {
        private ILocalStorage _storage;

        public LoginTest(ILocalStorage storage) {
            _storage = storage;
        }

        public async Task<bool> LoginAsync(LoginModel loginData) {

            try {
                TokenModel token_test = new TokenModel() { AuthToken = "TokenValue", expireDate = DateTime.Today.AddDays(5) };
                await _storage.SetStorageAsync<TokenModel>("authToken", token_test);
            } catch (HttpRequestException a) {
                Console.WriteLine(a.Data + "1");
            } catch (TaskCanceledException e) {
                Console.WriteLine(e.Data + "2");
            } catch (Exception m){
                Console.WriteLine(m.Data + "3");
            }

            return true;
        }
    }
}