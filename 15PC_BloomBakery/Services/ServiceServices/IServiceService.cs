using _15PC_BloomBakery.DTOs.ServiceDTOs;

namespace _15PC_BloomBakery.Services.ServiceServices
{
    public interface IServiceService
    {
        Task<List<ResultServiceDto>> GetAllServicesAsync();
        Task CreateServiceAsync(CreateServiceDto createServiceDto);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task DeleteServiceAsync(int id);
        Task<GetServiceDto> GetServiceByIdAsync(int id);
    }
}
