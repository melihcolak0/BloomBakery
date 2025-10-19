namespace _15PC_BloomBakery.DTOs.OrderDTOs
{
    public class CreateOrderDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
    }
}
