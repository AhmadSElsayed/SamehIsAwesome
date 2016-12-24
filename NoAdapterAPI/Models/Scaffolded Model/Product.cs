namespace NoAdapterAPI.Models
{ 
    public partial class Product
    {
        public int BarCode { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public string Gender { get; set; }
        public decimal Price { get; set; }
        public string ProductStatus { get; set; }
        public byte[] Image { get; set; }
        public int CategoryID { get; set; }
        public string BrandName { get; set; }
    }
}
