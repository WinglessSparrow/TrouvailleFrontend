using System.Threading.Tasks;
using System;
using TrouvailleFrontend.Shared.Classes.API;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class OrderTest : IOrder {
        public async Task<bool> OrderAsync(OrderModel order) {
            //just here to make the compiler shut up
            await Task.Run(() => { Console.WriteLine(); });
            
            return true;
        }
    }
}