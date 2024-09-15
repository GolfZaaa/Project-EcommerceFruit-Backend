using ProjectEcommerceFruit.Dtos.ProductGI;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.ProductGiS
{
    public interface IProductGIService
    {
        Task<List<ProductGIRespone>> GetProductGIAsync(int id);
        Task<Object> CreateUpdateProductGIAsync(ProductGIRequest request);
        Task<Object> RemoveProductGIAsync(int productGIId);
        Task<Object> RemoveImageAsync(int productGiId);
        Task<Object> HiddenProductGIAsync(int productGIId);

        //--------------------------------------category--------------------------------------------//

        Task<List<Category>> GetCategoriesAsync();
        Task<bool> CreateUpdateCategoryAsync(Category request);
        Task<Object> RemoveCategoryAsync(int categoryId);
        Task<dynamic> ProductGIAllAsync();
    }
}