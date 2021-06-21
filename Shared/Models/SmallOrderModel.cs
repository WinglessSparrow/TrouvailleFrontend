using System;
using System.Collections.Generic;
using TrouvailleFrontend.Shared.Enums;

namespace TrouvailleFrontend.Shared.Models {
    public class SmallOrderModel {
        private Guid _id;
        public string OrderId { get { return _id.ToString(); } set { _id = new Guid(value); } }
        public DateTime Date { get; set; }
        public decimal TotalCost { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ShipmentMethod ShipmentMethod { get; set; }
        public OrderState OrderState { get; set; }
        public AddressModel DeliveryAddress { get; set; }
        public AddressModel InvoiceAddress { get; set; }
        public List<ShoppingCartItemModel> Products { get; set; }
    }
}