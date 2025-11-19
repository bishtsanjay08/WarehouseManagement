using WarehouseManagement.Models;
using WarehouseManagement.Repositories.Interfaces;
using WarehouseManagement.Services.Interfaces;

namespace WarehouseManagement.Services.Implementations
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _repo;

        public StoreService(IStoreRepository repo)
        {
            this._repo = repo;
        }

        public async Task<List<Store>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Store?> GetByIdAsync(int Id)
        {
            var result = await _repo.GetByIdAsync(Id);

            if (result == null)
                return null;
            return result;
        }
    }
}
