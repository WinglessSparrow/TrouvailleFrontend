using System;
using System.Collections.Generic;

namespace TrouvailleFrontend.Shared.Models {
    public class OrderModel {
        public DateTime Date {get; set;}
        public PaymentMethod PaymentMethod { get; set; }
        public ShipmentMethod ShipmentMethod { get; set; }
        public AddressModel DeliveryAddress { get; set; }
        public AddressModel InvoiceAddress { get; set; }
        public List<ShoppingCartItemModel> Products { get; set; }
    }

    public enum PaymentMethod {
        Rechnung, Vorkasse, Paypal
    }

    public enum ShipmentMethod {
        dhl, dpd, ups, hermes
    }
}