using _15PC_BloomBakery.Context;
using _15PC_BloomBakery.DTOs.SliderDTOs;
using _15PC_BloomBakery.Entities;
using _15PC_BloomBakery.Services.SliderServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _15PC_BloomBakery.Services.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SliderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            var slider = _mapper.Map<Slider>(createSliderDto);
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSliderAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return;

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<GetSliderDto> GetSliderByIdAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            return _mapper.Map<GetSliderDto>(slider);
        }

        public async Task<List<ResultSliderDto>> GetAllSlidersAsync()
        {
            var sliders = await _context.Sliders.OrderBy(x => x.SliderId).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(sliders);
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            var slider = await _context.Sliders.FindAsync(updateSliderDto.SliderId);
            if (slider == null) return;

            _mapper.Map(updateSliderDto, slider);
            await _context.SaveChangesAsync();
        }
    }
}
