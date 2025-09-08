namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResponseProductDto
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string CoverImagePath { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string CategoryID { get; set; }
    }
}
