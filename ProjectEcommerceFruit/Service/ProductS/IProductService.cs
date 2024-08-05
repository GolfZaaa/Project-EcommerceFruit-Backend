using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Dtos.Product;

namespace ProjectEcommerceFruit.Service.ProductS
{
    public interface IProductService
    {
        Task<List<ProductRespone>> GetProductAsync(int categoryId);
        Task<List<ProductRespone>> GetProductByStoreAsync(int storeId);
        Task<Object> CreateUpdateProductAsync(ProductRequest request);
        Task<Object> RemoveProductByIdAsync(int productId);
    }
}