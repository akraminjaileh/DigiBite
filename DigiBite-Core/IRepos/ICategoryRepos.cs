using DigiBite_Core.DTOs.Category;

namespace DigiBite_Core.IRepos
{
    public interface ICategoryRepos
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDetailsDTO> GetCategoryById(int id);
    }
}
