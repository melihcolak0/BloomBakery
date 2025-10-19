using _15PC_BloomBakery.DTOs.CategoryDTOs;

namespace _15PC_BloomBakery.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task<GetCategoryDto> GetCategoryByIdAsync(int id);
    }
}
