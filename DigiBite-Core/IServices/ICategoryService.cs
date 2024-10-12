using DigiBite_Core.DTOs.Category;

namespace DigiBite_Core.IServices
{
    public interface ICategoryService
    {
        Task<int> AddCategory(AddCategoryDTO input, string createdBy);
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDetailsDTO> GetCategoryDetails(int id);
        Task<int> RemoveCategory(int id, string modifiedBy);
        Task<int> UpdateCategory(int id, UpdateCategoryDTO input, string lastModifiedBy);
        Task<int> UpdateCategoryImage(int catId, int imageId, string lastModifiedBy);
    }
}
