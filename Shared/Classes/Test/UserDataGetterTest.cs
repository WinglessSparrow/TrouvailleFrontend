using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TrouvailleFrontend.Shared.Classes.Interfaces;
using TrouvailleFrontend.Shared.Models;

namespace TrouvailleFrontend.Shared.Classes.Test {
    public class UserDataGetterTest : IUserDataGetter {
        public Task<List<OrderModel>> getOrderHistoryAsync() {
            throw new System.NotImplementedException();
        }

        public async Task<UserModel> getUserDataAsync() {

            await Task.Run(() => { Thread.Sleep(50); });

            return new UserModel() {
                Id = "123210ßid0299u",
                Email = "e@mail.com",
                PhoneNumber = "+499999",
                FirstName = "Jouske",
                LastName = "Higashikata",
                InvoiceAddress = new() {
                    Country = "Estonia",
                    State = "Harjuma",
                    PostalCode = 12356,
                    CityName = "Tallinn",
                    Street = "Neeme",
                    StreetNumber = 1
                },
                DeliveryAddress = new() {
                    Country = "Germany",
                    State = "Baden",
                    PostalCode = 12356,
                    CityName = "Rastatt",
                    Street = "Lenin Strasse",
                    StreetNumber = 1
                }
            };
        }
    }
}