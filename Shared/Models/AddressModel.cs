using System;
using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models {
    public class AddressModel {
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        public Nullable<int> PostalCode { get; set; } = null;
        [Required]
        [StringLength(50)]
        public string CityName { get; set; }
        [Required]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        public Nullable<int> StreetNumber { get; set; } = null;
    }
}