using DigiBite_Core.DTOs.Meal;

namespace DigiBite_Core.IServices
{
    public interface IMealService
    {
        Task<IEnumerable<MealDTO>> GetMeals(int skip, int take);

    }
}
