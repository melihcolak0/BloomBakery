using _15PC_BloomBakery.DTOs.OrderDTOs;

namespace _15PC_BloomBakery.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetAllOrderAsync();
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task UpdateOrderAsync(UpdateOrderDto updateOrderDto);
        Task DeleteOrderAsync(int id);
        Task<GetOrderDto> GetOrderByIdAsync(int id);
    }
}
