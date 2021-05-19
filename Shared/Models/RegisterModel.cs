using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrouvailleFrontend.Shared.Models {
    public class RegisterModel {
        [Required(ErrorMessage = "Please fill this Field")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please fill this Field")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please fill this Field")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "password must be at least 8 characters long")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please fill this Field")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please fill this Field")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please fill this Field")]
        [StringLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please fill this Field")]
        [StringLength(50)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please fill this Field")]
        [StringLength(50)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please fill this Field")]
        public int StreetNumber { get; set; }

        [Required(ErrorMessage = "Please fill this Field")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Please fill this Field")]
        [StringLength(50)]
        public string CityName { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}