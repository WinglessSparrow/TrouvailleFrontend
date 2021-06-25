using System;

namespace TrouvailleFrontend.Shared.Models {
    public class ProductModel {
        private Guid _id;
        public string ProductId { get { return _id.ToString(); } set { _id = new Guid(value); } }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Rating { get; set; }
        public decimal Tax { get; set; }
        public PictureModel Picture { get; set; }
    }
}

