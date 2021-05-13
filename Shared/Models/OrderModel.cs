using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrouvailleFrontend.Shared.Enums;
using System.Text.Json;

namespace TrouvailleFrontend.Shared.Models {
    public class OrderModel {
        [Required]
        public PaymentMethod PaymentMethod { get; set; }
        [Required]
        public ShipmentMethod ShipmentMethod { get; set; }
        [ValidateComplexType]
        public AddressModel DeliveryAddress { get; set; } = new AddressModel();
        [ValidateComplexType]
        public AddressModel InvoiceAddress { get; set; } = new AddressModel();
        [ValidateComplexType]
        public List<ShoppingCartItemModel> Products { get; set; } = new List<ShoppingCartItemModel>();
    }
}