using _15PC_BloomBakery.Context;
using _15PC_BloomBakery.DTOs.ServiceDTOs;
using _15PC_BloomBakery.Entities;
using _15PC_BloomBakery.Services.ServiceServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _15PC_BloomBakery.Services.ServiceServices
{
    public class ServiceService : IServiceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ServiceService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            var service = _mapper.Map<Service>(createServiceDto);
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }

        public async Task<GetServiceDto> GetServiceByIdAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            return _mapper.Map<GetServiceDto>(service);
        }

        public async Task<List<ResultServiceDto>> GetAllServicesAsync()
        {
            var services = await _context.Services.OrderBy(x => x.ServiceId).ToListAsync();
            return _mapper.Map<List<ResultServiceDto>>(services);
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            var service = await _context.Services.FindAsync(updateServiceDto.ServiceId);
            if (service == null) return;

            _mapper.Map(updateServiceDto, service);
            await _context.SaveChangesAsync();
        }
    }
}
