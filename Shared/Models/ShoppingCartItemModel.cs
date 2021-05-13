using System.ComponentModel.DataAnnotations;

namespace TrouvailleFrontend.Shared.Models {
    public class ShoppingCartItemModel {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Cardinality { get; set; }
    }
}