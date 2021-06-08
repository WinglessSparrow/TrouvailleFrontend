using System;
using System.Collections.Generic;

namespace TrouvailleFrontend.Shared.Models {
    public class UserModel {
        public string Id { get; set; } = "";
        public string Email { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public AddressModel InvoiceAddress { get; set; } = new();

        public AddressModel DeliveryAddress { get; set; } = new();

        public ICollection<Guid> Orders { get; set; }
    }
}