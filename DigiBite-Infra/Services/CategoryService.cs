using DigiBite_Core.DTOs.Category;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;

namespace DigiBite_Infra.Services
{
    public class CategoryService(
        ICategoryRepos repos,
        ICommandRepos command,
        IQueryRepos query
        ) : ICategoryService
    {
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
                 => await repos.GetCategories();

        public async Task<CategoryDetailsDTO> GetCategoryDetails(int id)
               => await repos.GetCategoryById(id);

        public async Task<int> AddCategory(AddCategoryDTO input, string createdBy)
        {
            try
            {
                var cat = new Category
                {
                    Name = input.Name,
                    NameEn = string.IsNullOrEmpty(input.NameEn) ? input.Name : input.NameEn,
                    Description = input.Description,
                    DescriptionEn = string.IsNullOrEmpty(input.DescriptionEn) ? input.Description : input.DescriptionEn,
                    CreatedBy = createdBy

                };

                var result = await command.AddAsync(cat);
                return cat.Id;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateCategory(int id, UpdateCategoryDTO input, string lastModifiedBy)
        {
            try
            {
                var cat = await query.GetEntityAsync<Category>(x => x.Id == id);

                cat.Name = input.Name ?? cat.Name;
                cat.NameEn = input.NameEn ?? cat.NameEn;
                cat.Description = input.Description ?? cat.Description;
                cat.DescriptionEn = input.DescriptionEn ?? cat.DescriptionEn;
                cat.LastModifiedBy = lastModifiedBy;
                cat.LastModifiedDateTime = DateTime.Now;

                return await command.UpdateAsync(cat);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateCategoryImage(int catId, int imageId, string lastModifiedBy)
        {
            if (!(imageId > 0)) return 0;

            var cat = await query.GetEntityAsync<Category>(x => x.Id == catId);
            if (cat == null)
                throw new Exception("Category not found");

            cat.LastModifiedBy = lastModifiedBy;
            cat.LastModifiedDateTime = DateTime.Now;
            cat.ImageId = imageId;
            return await command.UpdateAsync(cat);

        }

        public async Task<int> RemoveCategory(int id, string modifiedBy)
        {
            try
            {
                var cat = await query.GetEntityAsync<Category>(x => x.Id == id);

                cat.IsActive = false;
                cat.LastModifiedBy = modifiedBy;
                cat.LastModifiedDateTime = DateTime.Now;

                return await command.UpdateAsync(cat);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


    }
}
