using DigiBite_Core.DTOs.Ingredient;

namespace DigiBite_Core.IRepos
{
    public interface IIngredientRepos
    {
        Task<IngredientsDTO> GetIngredientById(int id);
        Task<IEnumerable<IngredientsDTO>> GetIngredients(int skip, int take, string sortBy = null, bool isDescending = false);
    }
}
