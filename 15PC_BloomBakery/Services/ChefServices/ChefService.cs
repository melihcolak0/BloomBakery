using _15PC_BloomBakery.Context;
using _15PC_BloomBakery.DTOs.ChefDTOs;
using _15PC_BloomBakery.Entities;
using _15PC_BloomBakery.Services.ChefServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _15PC_BloomBakery.Services.ChefServices
{
    public class ChefService : IChefService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ChefService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateChefAsync(CreateChefDto createChefDto)
        {
            var chef = _mapper.Map<Chef>(createChefDto);
            await _context.Chefs.AddAsync(chef);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChefAsync(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);
            if (chef == null) return;

            _context.Chefs.Remove(chef);
            await _context.SaveChangesAsync();
        }

        public async Task<GetChefDto> GetChefByIdAsync(int id)
        {
            var chef = await _context.Chefs.FindAsync(id);
            return _mapper.Map<GetChefDto>(chef);
        }

        public async Task<List<ResultChefDto>> GetAllChefsAsync()
        {
            var chefs = await _context.Chefs.OrderBy(x => x.ChefId).ToListAsync();
            return _mapper.Map<List<ResultChefDto>>(chefs);
        }

        public async Task UpdateChefAsync(UpdateChefDto updateChefDto)
        {
            var chef = await _context.Chefs.FindAsync(updateChefDto.ChefId);
            if (chef == null) return;

            _mapper.Map(updateChefDto, chef);
            await _context.SaveChangesAsync();
        }
    }
}
