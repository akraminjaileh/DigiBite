using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Ingredient;
using DigiBite_Core.Extension;
using DigiBite_Core.Helpers;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Repos
{
    public class IngredientRepos(DigiBiteContext context) : IIngredientRepos
    {

        public async Task<IEnumerable<IngredientsWithImageDTO>> GetIngredients(
            int skip, int take,
            string sortBy = null, bool isDescending = false)
        {
            var query = from ing in context.Ingredients
                        .Where(i => i.IsActive == true)
                        .ApplyFilterAndSort(null, sortBy, isDescending)
                        .Skip(skip)
                        .Take(take > 0 ? take : 20)
                        select new IngredientsWithImageDTO
                        {
                            Id = ing.Id,
                            Name = LanguageService.SelectLang(ing.Name, ing.NameEn),
                            ImageUrl = (from img in context.Medias
                                        where img.Id == ing.ImageId
                                        select img.ImageUrl).FirstOrDefault()
                        };
            return await query.ToListAsync();
        }

        public async Task<IngredientsWithImageDTO> GetIngredientById(int id)
        {
            var query = from ing in context.Ingredients
                        where ing.IsActive == true
                        select new IngredientsWithImageDTO
                        {
                            Id = ing.Id,
                            Name = LanguageService.SelectLang(ing.Name, ing.NameEn),
                            ImageUrl = (from img in context.Medias
                                        where img.Id == ing.ImageId
                                        select img.ImageUrl).FirstOrDefault()
                        };
            var ingredient = await query.FirstOrDefaultAsync();
            return ingredient!= null ? ingredient : throw new Exception("Ingredient not found");
        }

    }
}
