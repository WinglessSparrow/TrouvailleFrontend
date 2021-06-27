using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models {
    public class RegisterModel {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[\]:;<>,.?\/~_+-=|]).{6,}$", ErrorMessage = "Password Must be at least 6 characters long and containt one lower-, one uppercase letter and one special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your Password")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[\]:;<>,.?\/~_+-=|]).{6,}$", ErrorMessage = " ")]
        [CompareProperty("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
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