namespace MultiShop.Cargo.DtoLayer.DTOs.CargoDetailDtos;

public class UpdateCargoDetailDto
{
    public int ID { get; set; }

    public string SenderCustomer { get; set; }

    public string ReceiverCustomer { get; set; }

    public int Barcode { get; set; }

    public int CargoCompanyID { get; set; }
}
