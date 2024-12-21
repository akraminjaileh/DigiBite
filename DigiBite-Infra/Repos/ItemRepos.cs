using DigiBite_Core.Context;
using DigiBite_Core.DTOs.AddOnContainer;
using DigiBite_Core.DTOs.Ingredient;
using DigiBite_Core.DTOs.Item;
using DigiBite_Core.DTOs.Media;
using DigiBite_Core.Extension;
using DigiBite_Core.Helpers;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Repos
{
    public class ItemRepos(DigiBiteContext context) : IItemRepos
    {

        public async Task<PaginatedResult<ItemsDTO>> GetItems(
            int skip, int take,
            Dictionary<string, string> orderBy,
            string sortBy = null, bool isDescending = false)
        {
            var items = from item in context.Items
                        .Where(i => i.IsActive == true)
                        .ApplyFilterAndSort(orderBy, sortBy, isDescending)
                        .Skip(skip)
                        .Take(take > 0 ? take : 20)
                        select new ItemsDTO
                        {
                            Id = item.Id,
                            Name = LanguageService.SelectLang(item.Name, item.NameEn),
                            Price = item.Price,
                            IsAvailable = item.IsAvailable,
                            IsInMenu = item.IsInMenu,


                            Ingredients = (from itemIngred in context.ItemIngredients
                                           join ingred in context.Ingredients
                                           on itemIngred.IngredientId equals ingred.Id
                                           where itemIngred.ItemId == item.Id
                                           select new IngredientsWithDetailsDTO
                                           {
                                               Id = ingred.Id,
                                               Name = LanguageService.SelectLang(ingred.Name, ingred.NameEn),
                                               IngredientUnit = itemIngred.Unit.ToString(),
                                               QTY = itemIngred.QTY
                                           }).ToList(),

                            PrimaryImageUrl = (from img in context.Medias
                                               join imgItem in context.MediaItems
                                               on img.Id equals imgItem.MediaId
                                               where imgItem.ItemId == item.Id && imgItem.IsPrimary
                                               select new ImageAltTextDTO
                                               {
                                                   FileName = img.FileName,
                                                   AltText = img.AltText,
                                                   ImageUrl = img.ImageUrl
                                               }).FirstOrDefault(),

                        };
            var totalRecords = await context.Items
                .Where(x => x.IsActive == true)
                .ApplyFilterAndSort(orderBy, sortBy, isDescending)
                .CountAsync();

            return new PaginatedResult<ItemsDTO>
            {
                Items = await items.ToListAsync(),
                TotalRecords = totalRecords
            };

        }




        public async Task<ItemDetailsDTO> GetItemDetails(int id)
        {
            var query = from item in context.Items
                        where item.Id == id && item.IsActive == true
                        select new ItemDetailsDTO
                        {
                            Id = item.Id,
                            Name = LanguageService.SelectLang(item.Name, item.NameEn),
                            Description = LanguageService.SelectLang(item.Description, item.DescriptionEn),
                            Price = item.Price,

                            CategoryName = (from cat in context.Categories
                                            where cat.Id == item.CategoryId
                                            select LanguageService.SelectLang(cat.Name, cat.NameEn)).SingleOrDefault(),

                            ImageUrls = (from img in context.Medias
                                         join imgItem in context.MediaItems
                                         on img.Id equals imgItem.MediaId
                                         where imgItem.ItemId == item.Id
                                         select new ImageAltTextDTO
                                         {
                                             FileName = img.FileName,
                                             AltText = img.AltText,
                                             ImageUrl = img.ImageUrl,
                                         }).ToList(),

                            Ingredients = (from itemIng in context.ItemIngredients
                                           join ing in context.Ingredients
                                           on itemIng.IngredientId equals ing.Id
                                           where itemIng.ItemId == item.Id
                                           select new IngredientsWithImageDTO
                                           {
                                               Id = ing.Id,
                                               Name = LanguageService.SelectLang(ing.Name, ing.NameEn),
                                               IngredientUnit = itemIng.Unit.ToString(),
                                               QTY = itemIng.QTY,
                                               ImageUrl = (from img in context.Medias
                                                           where ing.ImageId == img.Id
                                                           select img.ImageUrl).SingleOrDefault(),
                                           }).ToList(),

                            AddOnContainers = (from addcon in context.AddOnContainers
                                               join addonItem in context.AddOnItemMeals
                                               on addcon.Id equals addonItem.AddOnContainerId
                                               where addonItem.ItemId == item.Id
                                               select new AddOnContainerDTO
                                               {
                                                   Id = addcon.Id,
                                                   Name = LanguageService.SelectLang(addcon.Name, addcon.NameEn),
                                                   Addons = (from addon in context.AddOns
                                                             where addon.AddOnContainerId == addcon.Id
                                                             select new AddOnDTO
                                                             {
                                                                 Id = addon.Id,
                                                                 Name = LanguageService.SelectLang(addon.Name, addon.NameEn),
                                                                 Price = addon.Price,
                                                                 ImageUrl = (from img in context.Medias
                                                                             where addon.ImageId == img.Id
                                                                             select img.ImageUrl).SingleOrDefault()
                                                             }).ToList()
                                               }).ToList(),




                            CreatedBy = item.CreatedBy,
                            CreationDateTime = item.CreationDateTime,
                            IsAvailable = item.IsAvailable,
                            IsInMenu = item.IsInMenu,
                            LastModifiedBy = item.LastModifiedBy,
                            LastModifiedDateTime = item.LastModifiedDateTime,

                        };

            return await query.SingleOrDefaultAsync();
        }




    }
}
