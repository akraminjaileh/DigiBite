using DigiBite_Core.DTOs.Meal;

namespace DigiBite_Core.IRepos
{
    public interface IMealRepos
    {
        Task<MealDetailsDTO> GetMealDetails(int id);
        Task<IEnumerable<MealsDTO>> GetMeals(int skip, int take, Dictionary<string, string> orderBy, string sortBy, bool isDescending);
    }
}
