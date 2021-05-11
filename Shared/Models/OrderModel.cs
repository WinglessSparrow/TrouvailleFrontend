using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models {
    public class OrderModel {
        [Required]
        public PaymentMethod PaymentMethod { get; set; }
        [Required]
        public ShipmentMethod ShipmentMethod { get; set; }
        public AddressModel DeliveryAddress { get; set; } = new AddressModel();
        [Required]
        public AddressModel InvoiceAddress { get; set; } = new AddressModel();
        [Required]
        public List<ShoppingCartItemModel> Products { get; set; } = new List<ShoppingCartItemModel>();

        // public override string ToString() {
        //     return $"Payment: {PaymentMethod} | "
        // }
    }

    public enum PaymentMethod {
        Rechnung, Vorkasse, Paypal
    }

    public enum ShipmentMethod {
        dhl, dpd, ups, hermes
    }
}