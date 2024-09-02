using ProjectEcommerceFruit.Dtos.ProductGI;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.ProductGiS
{
    public interface IProductGIService
    {
        Task<List<ProductGIRespone>> GetProductGIAsync();
        Task<Object> CreateUpdateProductGIAsync(ProductGIRequest request);
        Task<Object> RemoveProductGIAsync(int productGIId);
        Task<Object> RemoveImageAsync(int productGiId);

        //--------------------------------------category--------------------------------------------//

        Task<List<Category>> GetCategoriesAsync();
        Task<bool> CreateUpdateCategoryAsync(Category request);
        Task<Object> RemoveCategoryAsync(int categoryId);
    }
}