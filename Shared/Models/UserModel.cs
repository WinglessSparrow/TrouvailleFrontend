using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models {
    public class UserModel {
        public string Id { get; set; } = "";
        public string Email { get; set; } = "";

        [StringLength(50, MinimumLength = 7)]
        public string PhoneNumber { get; set; } = "";
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; } = "";
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; } = "";

        public AddressModel InvoiceAddress { get; set; } = new();

        public AddressModel DeliveryAddress { get; set; } = new();

        public ICollection<Guid> Orders { get; set; }
    }
}