namespace MultiShop.Cargo.DtoLayer.DTOs.CargoOperationDtos;

public class UpdateCargoOperationDto
{
    public int ID { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}
