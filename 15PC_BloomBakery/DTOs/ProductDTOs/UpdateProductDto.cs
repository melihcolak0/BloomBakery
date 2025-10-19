namespace _15PC_BloomBakery.DTOs.ProductDTOs
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
