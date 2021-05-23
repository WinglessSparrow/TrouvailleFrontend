using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.API
{
    public class RegisterAPI : IRegister {

        private IHttpRequest _requester;

        public RegisterAPI(IHttpRequest requester)
        {
            _requester = requester;
        }

        public async Task<bool> RegisterAsync(RegisterModel _registerData) {
            //TODO more checks
            var response = await _requester.PostRequestAsync<RegisterModel>(ApiPathsCentralDefinition.API_REGISTER, _registerData);

            if(response.IsSuccessStatusCode){
                return true;
            }

            return false;
        }
    }
}