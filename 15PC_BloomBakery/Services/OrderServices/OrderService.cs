using _15PC_BloomBakery.Context;
using _15PC_BloomBakery.DTOs.AboutDTOs;
using _15PC_BloomBakery.DTOs.OrderDTOs;
using _15PC_BloomBakery.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _15PC_BloomBakery.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);

            order.OrderDate = DateTime.SpecifyKind(order.OrderDate, DateTimeKind.Utc);

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<GetOrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.Include(x => x.Product).FirstOrDefaultAsync(y => y.OrderId == id);
            return _mapper.Map<GetOrderDto>(order);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var orders = await _context.Orders.Include(x => x.Product).OrderBy(x => x.OrderId).ToListAsync();
            return _mapper.Map<List<ResultOrderDto>>(orders);
        }

        public async Task UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            var order = await _context.Orders.FindAsync(updateOrderDto.OrderId);
            if (order == null) return;

            _mapper.Map(updateOrderDto, order);

            order.OrderDate = DateTime.SpecifyKind(order.OrderDate, DateTimeKind.Utc);

            await _context.SaveChangesAsync();
        }
    }
}
