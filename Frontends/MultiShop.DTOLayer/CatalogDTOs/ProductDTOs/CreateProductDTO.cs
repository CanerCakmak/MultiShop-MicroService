namespace MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;

public class CreateProductDTO
{
    public string Name { get; set; }
    public string CoverImagePath { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public string CategoryID { get; set; }
}
