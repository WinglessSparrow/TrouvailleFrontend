using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Models {
    public class RegisterModel {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Code is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "password must be at least 8 characters long")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int? StreetNumber { get; set; }
        public int? PostalCode { get; set; }
        public string CityName { get; set; }
    }
}