using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models {
    public class UserModel {
        public string Id { get; set; } = "";
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = "";
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "The number is not in a valid Format")]
        public string PhoneNumber { get; set; } = "";
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First name is required and must be bigger than 3 symbols long")]
        public string FirstName { get; set; } = "";
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name is required and must be bigger than 3 symbols long")]
        public string LastName { get; set; } = "";
        [ValidateComplexType]
        public AddressModel InvoiceAddress { get; set; } = new();
        [ValidateComplexType]
        public AddressModel DeliveryAddress { get; set; } = new();

        public ICollection<Guid> Orders { get; set; }
        public bool IsDisabled { get; set; } = false;
    }
}