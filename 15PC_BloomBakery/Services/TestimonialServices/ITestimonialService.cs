using _15PC_BloomBakery.DTOs.TestimonialDTOs;

namespace _15PC_BloomBakery.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task DeleteTestimonialAsync(int id);
        Task<GetTestimonialDto> GetTestimonialByIdAsync(int id);
    }
}
