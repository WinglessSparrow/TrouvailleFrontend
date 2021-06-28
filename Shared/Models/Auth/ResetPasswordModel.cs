using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models.Auth {
    public class ResetPasswordModel {
        [Required(ErrorMessage = "New Password is required")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[\]:;<>,.?\/~_+-=|]).{8,}$", ErrorMessage = "Password Must be at least 6 characters long and containt one lower-, one uppercase letter and one special character")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm New Password")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[\]:;<>,.?\/~_+-=|]).{8,}$", ErrorMessage = " ")]
        [CompareProperty("NewPassword", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}