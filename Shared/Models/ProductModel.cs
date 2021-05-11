
namespace TrouvailleFrontend.Shared.Models {
    public class ProductModel {
        //Product Id
        public int Pid { get; set; }

        //Categories Id
        public int[] Cid { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Rating { get; set; }

        public int MinStock { get; set; }
        //Tax
        public int Vat { get; set; }
        //Image Id
        public int IId { get; set; }
    }
}

