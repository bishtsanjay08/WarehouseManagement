using WarehouseManagement.Models;

namespace WarehouseManagement.Services.Interfaces
{
    public interface IStoreService
    {
        Task<List<Store>> GetAllAsync();
        Task<Store?> GetByIdAsync(int Id);

    }
}
