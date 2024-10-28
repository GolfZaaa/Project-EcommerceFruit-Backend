using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Dtos.Product;

namespace ProjectEcommerceFruit.Service.ProductS
{
    public interface IProductService
    {
        Task<List<ProductRespone>> SearchProductAsync(string productName);
        Task<List<ProductRespone>> GetFilterProductAsync(FilterProducts request);
        Task<List<ProductRespone>> GetProductAsync(int categoryId);
        Task<Object> GetProductByIdAsync(int productId);
        Task<List<ProductRespone>> GetProductByStoreAsync(int storeId);
        Task<Object> CreateUpdateProductAsync(ProductRequest request);
        Task<Object> IsUsedProductByIdAsync(int productId); 
        Task<Object> RemoveProductByIdAsync(int productId);
        Task<dynamic> ProductAllAsync();
        Task<Object> AddStockProductAsync(AddStockProductDto dto);
    }
}