using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class OrderRetrieverTest : IOrderRetriever {
        public Task<SmallOrderModel> GetSlimOrderAsync() {
            throw new System.NotImplementedException();
        }

        public async Task<List<SmallOrderModel>> GetSlimOrdersAsync() {
            await Task.Run(() => Thread.Sleep(5));

            return new List<SmallOrderModel>()
            {
               new SmallOrderModel()
               {
                   OrderId = "d113e066-48f7-4bcb-852f-a81d4f2c792e",
                   Date = DateTime.Now,
                   TotalCost = 20.50m,
                   PaymentMethod = Enums.PaymentMethod.Paypal,
                   ShipmentMethod = Enums.ShipmentMethod.dhl,
                   OrderState = Enums.OrderState.Bestellt
                   //TODO, finish data 
               }
            };
        }
    }
}