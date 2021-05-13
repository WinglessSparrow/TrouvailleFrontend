using System;

namespace TrouvailleFrontend.Shared.Models {
    public class ProductModel {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
        public int Rating { get; set; }
        public int Tax { get; set; }
        public PictureModel Picture { get; set; }
    }
}

