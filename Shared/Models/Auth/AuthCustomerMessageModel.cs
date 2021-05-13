using System;

namespace TrouvailleFrontend.Shared.Models {
    public class AuthCustomerMessageModel {
        public string message{ get; set; }
        public bool isSucces { get; set; }

        public string errors {get; set;}

        public DateTime expireDate {get; set;}
    }
}