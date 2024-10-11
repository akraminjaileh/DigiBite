using DigiBite_Core.DTOs.Item;
using DigiBite_Core.DTOs.Meal;

namespace DigiBite_Core.IServices
{
    public interface IMealService
    {
        Task<int> AddMealWithDetails(AddMealDTO input, string createdBy);
        Task<int> BulkRemoveMeal(List<int> mealId, string lastModifiedBy);
        Task<MealDetailsDTO> GetMealDetails(int id);
        Task<IEnumerable<MealsDTO>> GetMeals(int skip, int take, Dictionary<string, string> orderBy, string sortBy = null, bool isDescending = false);
        Task<int> RemoveMeal(int mealId, string lastModifiedBy);
        Task<int> UpdateMealImages(int mealId, List<ItemImagesDTO> inputs, string lastModifiedBy);
        Task<int> UpdateMealWithDetails(UpdateMealDTO input, string lastModifiedBy, int mealId);
    }
}
