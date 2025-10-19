using _15PC_BloomBakery.Context;
using _15PC_BloomBakery.DTOs.TestimonialDTOs;
using _15PC_BloomBakery.Entities;
using _15PC_BloomBakery.Services.TestimonialServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _15PC_BloomBakery.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TestimonialService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            var about = _mapper.Map<Testimonial>(createTestimonialDto);
            await _context.Testimonials.AddAsync(about);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            var about = await _context.Testimonials.FindAsync(id);
            if (about == null) return;

            _context.Testimonials.Remove(about);
            await _context.SaveChangesAsync();
        }

        public async Task<GetTestimonialDto> GetTestimonialByIdAsync(int id)
        {
            var about = await _context.Testimonials.FindAsync(id);
            return _mapper.Map<GetTestimonialDto>(about);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync()
        {
            var abouts = await _context.Testimonials.OrderBy(x => x.TestimonialId).ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(abouts);
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var about = await _context.Testimonials.FindAsync(updateTestimonialDto.TestimonialId);
            if (about == null) return;

            _mapper.Map(updateTestimonialDto, about);
            await _context.SaveChangesAsync();
        }
    }
}
