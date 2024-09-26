using DigiBite_Core.DTOs.Meal;
using DigiBite_Core.Helpers;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Services
{
    public class MealService : IMealService
    {
        public async Task<IEnumerable<MealDTO>> GetMeals(int skip, int take)
        {
            return new List<MealDTO>();
        }
    }
}
