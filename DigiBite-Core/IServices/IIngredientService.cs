using DigiBite_Core.DTOs.Ingredient;

namespace DigiBite_Core.IServices
{
    public interface IIngredientService
    {
        Task<int> AddIngredient(AddIngredientDTO input, string createdBy);
        Task<int> BulkRemoveIngredient(List<int> ingId, string lastModifiedBy);
        Task<IngredientsWithImageDTO> GetIngredientDetails(int id);
        Task<IEnumerable<IngredientsWithImageDTO>> GetIngredients(int skip, int take, string sortBy = null, bool isDescending = false);
        Task<int> RemoveIngredient(int id, string modifiedBy);
        Task<int> UpdateIngredient(int id, AddIngredientDTO input, string lastModifiedBy);
        Task<int> UpdateIngredientImage(int ingId, int imageId, string lastModifiedBy);
    }
}
