using WarehouseManagement.Models;

namespace WarehouseManagement.Services.Interfaces
{
    public interface IStoreService
    {
        Task<List<Store>> GetAllAsync();
        
        Task<Store?> GetByIdAsync(int Id);

        Task<Store> AddAsync(Store store);

        Task<Store?> UpdateAsync(Store store);

        Task<bool> DeleteAsync(int Id);

    }
}
