using DigiBite_Core.Context;
using DigiBite_Core.DTOs.AddOnContainer;
using DigiBite_Core.DTOs.Item;
using DigiBite_Core.DTOs.Meal;
using DigiBite_Core.Extension;
using DigiBite_Core.Helpers;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Repos
{
    public class MealRepos(DigiBiteContext context) : IMealRepos
    {

        public async Task<IEnumerable<MealsDTO>> GetMeals(
            int skip, int take,
            Dictionary<string, string> orderBy,
            string sortBy = null, bool isDescending = false)
        {
            var meals = from meal in context.Meals
                        .Where(i => i.IsActive == true)
                        .ApplyFilterAndSort(orderBy, sortBy, isDescending)
                        .Skip(skip)
                        .Take(take > 0 ? take : 20)
                        select new MealsDTO
                        {
                            Id = meal.Id,
                            Name = LanguageService.SelectLang(meal.Name, meal.NameEn),
                            Price = meal.Price,
                            IsAvailable = meal.IsAvailable,
                            IsInMenu = meal.IsInMenu,


                            Items = (from itemMeal in context.ItemMeals
                                     join item in context.Items
                                     on itemMeal.MealId equals item.Id
                                     where itemMeal.MealId == meal.Id
                                     select new ItemOnMealDTO
                                     {
                                         Name = LanguageService.SelectLang(item.Name, item.NameEn),
                                         QTY = itemMeal.QTY
                                     }).ToList(),

                            PrimaryImageUrl = (from img in context.Medias
                                               join imgMeal in context.MediaItems
                                               on img.Id equals imgMeal.MediaId
                                               where imgMeal.MealId == meal.Id && imgMeal.IsPrimary
                                               select img.ImageUrl).FirstOrDefault()


                        };

            return await meals.ToListAsync();

        }


        public async Task<MealDetailsDTO> GetMealDetails(int id)
        {
            var query = from meal in context.Meals
                        where meal.Id == id && meal.IsActive == true
                        select new MealDetailsDTO
                        {
                            Id = meal.Id,
                            Name = LanguageService.SelectLang(meal.Name, meal.NameEn),
                            Description = LanguageService.SelectLang(meal.Description, meal.DescriptionEn),
                            Price = meal.Price,

                            CategoryName = (from cat in context.Categories
                                            where cat.Id == meal.CategoryId
                                            select cat.Name).SingleOrDefault(),

                            ImageUrls = (from img in context.Medias
                                         join imgMeal in context.MediaItems
                                         on img.Id equals imgMeal.MediaId
                                         where imgMeal.MealId == meal.Id
                                         select img.ImageUrl).ToList(),

                            Items = (from mealItem in context.ItemMeals
                                     join item in context.Items
                                     on mealItem.ItemId equals item.Id
                                     where mealItem.MealId == meal.Id
                                     select new ItemOnMealWithImageDTO
                                     {

                                         Name = LanguageService.SelectLang(item.Name, item.NameEn),
                                         QTY = mealItem.QTY,
                                         PrimaryImageUrl = (from img in context.Medias
                                                            join itemImage in context.MediaItems
                                                            on img.Id equals itemImage.MediaId
                                                            where itemImage.ItemId == item.Id && itemImage.IsPrimary
                                                            select img.ImageUrl).SingleOrDefault(),
                                     }).ToList(),

                            AddOnContainers = (from addcon in context.AddOnContainers
                                               join addonMeal in context.AddOnItemMeals
                                               on addcon.Id equals addonMeal.AddOnContainerId
                                               where addonMeal.MealId == meal.Id
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




                            CreatedBy = meal.CreatedBy,
                            CreationDateTime = meal.CreationDateTime,
                            IsAvailable = meal.IsAvailable,
                            IsInMenu = meal.IsInMenu,
                            LastModifiedBy = meal.LastModifiedBy,
                            LastModifiedDateTime = meal.LastModifiedDateTime,

                        };

            return await query.SingleOrDefaultAsync();

        }


    }
}
