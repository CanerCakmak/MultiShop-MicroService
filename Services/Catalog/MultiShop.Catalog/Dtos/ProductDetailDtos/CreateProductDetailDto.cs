﻿namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public class CreateProductDetailDto
    {
        public string Description { get; set; }
        public string Info { get; set; }
        public int StockCount { get; set; }

        public string ProductID { get; set; }
    }
}
