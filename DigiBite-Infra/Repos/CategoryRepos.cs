using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Category;
using DigiBite_Core.DTOs.Media;
using DigiBite_Core.Helpers;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Repos
{
    public class CategoryRepos(DigiBiteContext context) : ICategoryRepos
    {

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var query = from cat in context.Categories
                        where cat.IsActive == true
                        select new CategoryDTO
                        {
                            Id = cat.Id,
                            Name = LanguageService.SelectLang(cat.Name, cat.NameEn),
                            ImageUrl = (from img in context.Medias
                                        where img.Id == cat.ImageId
                                        select new ImageAltTextDTO
                                        {
                                            FileName = img.FileName,
                                            AltText = img.AltText,
                                            ImageUrl = img.ImageUrl
                                        }).FirstOrDefault()
                        };
            return await query.ToListAsync();
        }

        public async Task<CategoryDetailsDTO> GetCategoryById(int id)
        {
            var query = from cat in context.Categories
                        where cat.Id == id && cat.IsActive == true
                        select new CategoryDetailsDTO
                        {
                            Name = LanguageService.SelectLang(cat.Name, cat.NameEn),
                            Description = LanguageService.SelectLang(cat.Description, cat.DescriptionEn),
                            ImageUrl = (from img in context.Medias
                                        where img.Id == cat.ImageId
                                        select img.ImageUrl).FirstOrDefault(),
                            CreatedBy = cat.CreatedBy,
                            CreationDateTime = cat.CreationDateTime,
                            LastModifiedBy = cat.LastModifiedBy,
                            LastModifiedDateTime = cat.LastModifiedDateTime
                        };
            var category = await query.FirstOrDefaultAsync();
            return category != null ? category : throw new Exception($"Category with id : {id} not found");
        }


    }
}
