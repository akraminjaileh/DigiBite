using DigiBite_Core.DTOs.Ingredient;

namespace DigiBite_Core.IRepos
{
    public interface IIngredientRepos
    {
        Task<IngredientsWithImageDTO> GetIngredientById(int id);
        Task<IEnumerable<IngredientsWithImageDTO>> GetIngredients(int skip, int take, string sortBy = null, bool isDescending = false);
    }
}
