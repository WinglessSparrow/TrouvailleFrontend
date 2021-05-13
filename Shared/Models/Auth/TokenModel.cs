using System;

namespace TrouvailleFrontend.Shared.Models {
    public class TokenModel {
        public string AuthToken { get; set; }
        public DateTime? expireDate {get; set;}
    }
}