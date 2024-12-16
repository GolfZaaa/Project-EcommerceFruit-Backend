using ProjectEcommerceFruit.Dtos.Product;
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
        Task<Object> DeleteStoreAsync(int id);
        Task<List<ProductRespone>> GetStoreProductUserAsync(FilterProductsStore request);
        Task<Object> GetStoreDetailByUserIdAsync(int userId);
    }
}
