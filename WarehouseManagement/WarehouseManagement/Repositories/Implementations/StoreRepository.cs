using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Data;
using WarehouseManagement.Models;
using WarehouseManagement.Repositories.Interfaces;

namespace WarehouseManagement.Repositories.Implementations
{
        public class StoreRepository : IStoreRepository
        {
            private readonly AppDbContext _db;

            public StoreRepository(AppDbContext appDbContext)
            {
                this._db = appDbContext;
            }

        public async Task<List<Store>> GetAllAsync()
        {
            var list = await _db.Stores.ToListAsync();

            return list;
        }

        public async Task<Store?> GetByIdAsync(int Id)
        {
            var result = await _db.Stores.FirstOrDefaultAsync(s => s.Id == Id);

            return result;
        }

        public async Task<Store> AddAsync(Store store)
        {
            _db.Stores.Add(store);
            await _db.SaveChangesAsync();
            return store;
        }

        public async Task<Store?> UpdateAsync(Store store)
        {
            var existing = await _db.Stores.FindAsync(store.Id);
            if (existing == null)
                return null;
            existing.Name = store.Name;
            existing.Location = store.Location;

            await _db.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var result = await _db.Stores.FindAsync(Id);
            if (result == null)
            {
                return false;
            }

            _db.Stores.Remove(result);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
