using System;
using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models {
    public class ShoppingCartItemModel {

        private Guid _id;

        [Required]
        public string ProductId { get { return _id.ToString(); } set { _id = new Guid(value); } }
        [Required]
        public int Cardinality { get; set; }
    }
}