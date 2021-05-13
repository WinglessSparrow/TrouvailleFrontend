using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrouvailleFrontend.Shared.Enums;

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
    }
}