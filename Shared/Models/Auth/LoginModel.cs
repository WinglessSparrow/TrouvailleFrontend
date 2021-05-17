using System;
using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models {
    public class LoginModel {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}