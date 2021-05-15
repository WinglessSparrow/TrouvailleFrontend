namespace TrouvailleFrontend.Shared.Classes.Functional {
    public class StockConverter {
        public static string ParseStockToString(int stock) {
            if (stock >= 30) return "In stock";
            if (stock < 30 && stock > 10) return "Limited";
            if (stock <= 10) return $"Only {stock} left";
            if (stock == 0) return "Not in Stock";
            return "wrong number";
        }
    }
}