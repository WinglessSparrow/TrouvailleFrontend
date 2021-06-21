using System.Net.Http;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class UserDataChangerAPI : IUserDataChanger {

        IErrorHandler _errorHandler;
        HttpRequest _httpRequest;

        public UserDataChangerAPI(IErrorHandler errorHandler, HttpRequest httpRequest) {
            _errorHandler = errorHandler;
            _httpRequest = httpRequest;
        }

        public async Task<bool> changeAddressAsync(UserModel userData) {
            
            bool success = false;

            try{

            }catch(HttpRequestException){
               // _errorHandler.SetLastError();
            }

            return success;
        }

        public Task<bool> changeUserDataAsync(UserModel userData) {
            throw new System.NotImplementedException();
        }
    }
}