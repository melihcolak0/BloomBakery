using _15PC_BloomBakery.DTOs.SliderDTOs;

namespace _15PC_BloomBakery.Services.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSlidersAsync();
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task DeleteSliderAsync(int id);
        Task<GetSliderDto> GetSliderByIdAsync(int id);
    }
}
