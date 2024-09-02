using ProjectEcommerceFruit.Dtos.Store;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.StoreS
{
    public interface IStoreService
    {
        Task<List<StoreRespone>> GetStoreAsync();
        Task<StoreRespone> GetStoreByUserIdAsync();
        Task<Object> CreateUpdateStoreAsync(StoreRequest request);
        Task<Object> RemoveStoreByIdAsync(int storeId);
        Task<dynamic> StoreAllAsync();
    }
}
