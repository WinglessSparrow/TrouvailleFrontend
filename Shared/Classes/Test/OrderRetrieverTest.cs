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
               new()
               {
                    OrderId = "d113e066-48f7-4bcb-852f-a81d4f2c792e",
                    Date = DateTime.Now,
                    TotalCost = 20.50m,
                    PaymentMethod = Enums.PaymentMethod.Paypal,
                    ShipmentMethod = Enums.ShipmentMethod.dhl,
                    OrderState = Enums.OrderState.Storniert,
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
                    },
                    Products = new()
                    {
                        new(){ProductId = "f0f7b8d4-0d2a-4c55-9a94-d91f39a93a1a", Cardinality = 2}
                    }
               },
                              new()
               {
                    OrderId = "d113e066-48f7-4bcb-852f-a81d4f2c792e",
                    Date = DateTime.Now,
                    TotalCost = 20.50m,
                    PaymentMethod = Enums.PaymentMethod.Paypal,
                    ShipmentMethod = Enums.ShipmentMethod.dhl,
                    OrderState = Enums.OrderState.Bestellt,
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
                    },
                    Products = new()
                    {
                        new(){ProductId = "f0f7b8d4-0d2a-4c55-9a94-d91f39a93a1a", Cardinality = 2},
                        new(){ProductId = "67862b3a-745c-434f-b7c2-1399262bf0da", Cardinality = 3},
                        new(){ProductId = "2ccfc4a7-af8c-40df-8483-0ef79fcb5bcd", Cardinality = 1}
                    }
               },
               new()
               {
                    OrderId = "d113f066-48f7-4bca-852f-a81d4f2c932e",
                    Date = DateTime.Now,
                    TotalCost = 300.50m,
                    PaymentMethod = Enums.PaymentMethod.Paypal,
                    ShipmentMethod = Enums.ShipmentMethod.dhl,
                    OrderState = Enums.OrderState.Unterwegs,
                    InvoiceAddress = new() {
                        Country = "USA",
                        State = "Kentucky",
                        PostalCode = 12356,
                        CityName = "New York",
                        Street = "Street",
                        StreetNumber = 1
                    },
                    DeliveryAddress = new() {
                        Country = "Germany",
                        State = "Baden",
                        PostalCode = 12356,
                        CityName = "Rastatt",
                        Street = "Lenin Strasse",
                        StreetNumber = 1
                    },
                    Products = new()
                    {
                        new(){ProductId = "f0f7b8d4-0d2a-4c55-9a94-d91f39a93a1a", Cardinality = 1},
                        new(){ProductId = "67862b3a-745c-434f-b7c2-1399262bf0da", Cardinality = 3},
                        new(){ProductId = "2ccfc4a7-af8c-40df-8483-0ef79fcb5bcd", Cardinality = 2},
                        new(){ProductId = "ef0e4781-d7f4-4d38-bce5-4c30427311fb", Cardinality = 1}
                    }
               },
                             new()
               {
                    OrderId = "dc13f066-4ff7-4bca-452f-a81d4f2c932f",
                    Date = DateTime.Now,
                    TotalCost = 300.50m,
                    PaymentMethod = Enums.PaymentMethod.Paypal,
                    ShipmentMethod = Enums.ShipmentMethod.dhl,
                    OrderState = Enums.OrderState.Zugestellt,
                    InvoiceAddress = new() {
                        Country = "USA",
                        State = "Kentucky",
                        PostalCode = 12356,
                        CityName = "New York",
                        Street = "Street",
                        StreetNumber = 1
                    },
                    DeliveryAddress = new() {
                        Country = "Germany",
                        State = "Baden",
                        PostalCode = 12356,
                        CityName = "Rastatt",
                        Street = "Lenin Strasse",
                        StreetNumber = 1
                    },
                    Products = new()
                    {
                        new(){ProductId = "f0f7b8d4-0d2a-4c55-9a94-d91f39a93a1a", Cardinality = 1},
                        new(){ProductId = "ef0e4781-d7f4-4d38-bce5-4c30427311fb", Cardinality = 1}
                    }
               }

            };
        }
    }
}