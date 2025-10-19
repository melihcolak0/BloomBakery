using _15PC_BloomBakery.DTOs.AboutDTOs;

namespace _15PC_BloomBakery.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutsAsync();
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAboutAsync(int id);
        Task<GetAboutDto> GetAboutByIdAsync(int id);
    }
}
