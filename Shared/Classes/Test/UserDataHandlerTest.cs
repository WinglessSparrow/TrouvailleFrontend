using System.Collections.Generic;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;


namespace TrouvailleFrontend.Shared.Classes.Test {
    public class UserDataHandlerTest : IUserDataHandler {

        private IHttpRequest _requestor;

        public UserDataHandlerTest(IHttpRequest request) {
            _requestor = request;
        }

        public void changeAddressAsync(UserModel userData) {
            throw new System.NotImplementedException();
        }

        public void changeUserDataAsync(UserModel userData) {
            throw new System.NotImplementedException();
        }

        public Task<List<OrderModel>> getOrderHistoryAsync() {
            throw new System.NotImplementedException();
        }
    }
}