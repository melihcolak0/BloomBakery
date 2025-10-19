using _15PC_BloomBakery.DTOs.ChefDTOs;

namespace _15PC_BloomBakery.Services.ChefServices
{
    public interface IChefService
    {
        Task<List<ResultChefDto>> GetAllChefsAsync();
        Task CreateChefAsync(CreateChefDto createChefDto);
        Task UpdateChefAsync(UpdateChefDto updateChefDto);
        Task DeleteChefAsync(int id);
        Task<GetChefDto> GetChefByIdAsync(int id);
    }
}
