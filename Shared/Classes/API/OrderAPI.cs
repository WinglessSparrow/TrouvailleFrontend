using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class OrderAPI : IOrder {

        private IHttpRequest _requester;
        public OrderAPI(IHttpRequest requester) {
            _requester = requester;
        }
        public async Task<bool> OrderAsync(OrderModel order) {
            var response = await _requester.PostRequestAsync<OrderModel>($"{ApiPathsCentralDefinition.API_ORDER}", order);

            if (response.IsSuccessStatusCode) {
                return true;
            } else {
                return false;
            }
        }
    }
}