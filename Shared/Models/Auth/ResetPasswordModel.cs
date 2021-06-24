using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models.Auth {
    public class ResetPasswordModel {
        [Required]
        [StringLength(50, MinimumLength = 6)]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "Passwords do not match")]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string ConfirmPassword { get; set; }
    }
}