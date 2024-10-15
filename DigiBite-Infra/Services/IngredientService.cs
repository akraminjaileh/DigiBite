using DigiBite_Core.Constant;
using DigiBite_Core.DTOs.Ingredient;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;

namespace DigiBite_Infra.Services
{
    public class IngredientService(IIngredientRepos repos, ICommandRepos command, IQueryRepos query) : IIngredientService
    {
        public async Task<IEnumerable<IngredientsWithImageDTO>> GetIngredients(int skip, int take,
            string sortBy = null, bool isDescending = false)
                 => await repos.GetIngredients(skip, take, sortBy, isDescending);

        public async Task<IngredientsWithImageDTO> GetIngredientDetails(int id)
               => await repos.GetIngredientById(id);

        public async Task<int> AddIngredient(AddIngredientDTO input, string createdBy)
        {
            try
            {
                var ing = new Ingredient
                {
                    Name = input.Name,
                    NameEn = string.IsNullOrEmpty(input.NameEn) ? input.Name : input.NameEn,
                    CreatedBy = createdBy
                };

                var result = await command.AddAsync(ing);
                return ing.Id;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateIngredient(int id, AddIngredientDTO input, string lastModifiedBy)
        {
            try
            {
                var ing = await query.GetEntityAsync<Ingredient>(x => x.Id == id);

                ing.Name = input.Name ?? ing.Name;
                ing.NameEn = input.NameEn ?? ing.NameEn;
                ing.LastModifiedBy = lastModifiedBy;
                ing.LastModifiedDateTime = DateTime.Now;

                return await command.UpdateAsync(ing);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateIngredientImage(int ingId, int imageId, string lastModifiedBy)
        {
            if (!(imageId > 0)) return 0;

            var ing = await query.GetEntityAsync<Ingredient>(x => x.Id == ingId);
            if (ing == null)
                throw new Exception("Ingredient not found");

            ing.LastModifiedBy = lastModifiedBy;
            ing.LastModifiedDateTime = DateTime.Now;
            ing.ImageId = imageId;
            return await command.UpdateAsync(ing);

        }

        public async Task<int> RemoveIngredient(int id, string modifiedBy)
        {
            try
            {
                var ing = await query.GetEntityAsync<Ingredient>(x => x.Id == id);

                ing.IsActive = false;
                ing.LastModifiedBy = modifiedBy;
                ing.LastModifiedDateTime = DateTime.Now;

                return await command.UpdateAsync(ing);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> BulkRemoveIngredient(List<int> ingId, string lastModifiedBy)
        {
            var ingredients = await query.GetEntitiesAsync<Item>(x => ingId.Contains(x.Id));
            foreach (var ing in ingredients)
            {
                ing.IsActive = false;
                ing.LastModifiedBy = lastModifiedBy;
                ing.LastModifiedDateTime = DateTime.Now;
            }

            return await command.UpdateRangAsync(ingredients);
        }

    }
}
