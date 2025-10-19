using _15PC_BloomBakery.Context;
using _15PC_BloomBakery.DTOs.AboutDTOs;
using _15PC_BloomBakery.Entities;
using AutoMapper;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace _15PC_BloomBakery.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AboutService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var about = _mapper.Map<About>(createAboutDto);
            await _context.Abouts.AddAsync(about);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAboutAsync(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            if (about == null) return;

            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
        }

        public async Task<GetAboutDto> GetAboutByIdAsync(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            return _mapper.Map<GetAboutDto>(about);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutsAsync()
        {
            var abouts = await _context.Abouts.OrderBy(x => x.AboutId).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(abouts);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var about = await _context.Abouts.FindAsync(updateAboutDto.AboutId);
            if (about == null) return;

            _mapper.Map(updateAboutDto, about);
            await _context.SaveChangesAsync();
        }
    }
}
