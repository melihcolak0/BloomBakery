using _15PC_BloomBakery.DTOs.ProductDTOs;

namespace _15PC_BloomBakery.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int id);
        Task<GetProductDto> GetProductByIdAsync(int id);
    }
}
