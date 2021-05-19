using System;
using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models {
    public class AddressModel {
        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Country Name too short")]
        public string Country { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "State Name too short")]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [Range(10000, 99999, ErrorMessage = "Postal Code must be 5 characters")]
        public int? PostalCode { get; set; } = null;

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "City Name too short")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Street Name too short")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Street Number is required")]
        public int? StreetNumber { get; set; } = null;

        public override string ToString() {
            return $"{Country} + {State} + {PostalCode} + {CityName} + {Street} + {StreetNumber}";
        }
    }
}