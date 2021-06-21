using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using TrouvailleFrontend.Shared.Models;
using TrouvailleFrontend.Shared.Models.Auth;
using TrouvailleFrontend.Shared.Classes.Interfaces;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class OrdererAPI : IOrderer {

        private IHttpRequest _requester;
        private IErrorHandler _errorHandler;
        public OrdererAPI(IHttpRequest requester, IErrorHandler errorHandler) {
            _requester = requester;
            _errorHandler = errorHandler;
        }
        public async Task<bool> OrderAsync(OrderModel order) {
        try {
                HttpResponseMessage response = await _requester.PostRequestAsync<OrderModel>($"{ApiPathsCentralDefinition.API_ORDER}", order);
                if (response.IsSuccessStatusCode) return true;

                _errorHandler.SetLastError(response);

            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return false;
        }
    }
}