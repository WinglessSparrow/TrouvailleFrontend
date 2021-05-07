namespace TrouvailleFrontend.Shared.Models {
    public class ShoppingCartItem {

        public ShoppingCartItem(int pid, int amount) {
            this.ProductId = pid;
            this.Cardinality = amount;
        }

        public int ProductId { get; set; }
        public int Cardinality { get; set; }
    }
}