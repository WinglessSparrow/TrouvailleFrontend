using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using TrouvailleFrontend.Shared.Models;
using TrouvailleFrontend.Shared.Models.Auth;
using TrouvailleFrontend.Shared.Classes.Interfaces;

namespace TrouvailleFrontend.Shared.Classes.API {
    public class OrderRetriever : IOrderRetriever {

        private IHttpRequest _requester;
        private IErrorHandler _errorHandler;
        public OrderRetriever(IHttpRequest requester, IErrorHandler errorHandler) {
            _requester = requester;
            _errorHandler = errorHandler;
        }
        public async Task<List<SmallOrderModel>> GetSlimOrdersAsync() {
            try {
                HttpResponseMessage response = await _requester.PostRequestAsync($"{ApiPathsCentralDefinition.API_GET_HISTORY}/0/100", "");
                if (response.IsSuccessStatusCode) {
                    
                    List<SmallOrderModel> smallOrderModels = await response.Content.ReadFromJsonAsync<List<SmallOrderModel>>();

                    return smallOrderModels;
                }

                _errorHandler.SetLastError(response);

            } catch (HttpRequestException) {
                _errorHandler.SetLastError(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
            }

            return null;
        }
    }
}