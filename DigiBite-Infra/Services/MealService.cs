using DigiBite_Core.DTOs.Item;
using DigiBite_Core.DTOs.Meal;
using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using DigiBite_Core.Models.ManyToMany;

namespace DigiBite_Infra.Services
{
    public class MealService(IMealRepos repos, ICommandRepos command, IQueryRepos query) : IMealService
    {

        public async Task<IEnumerable<MealsDTO>> GetMeals(int skip, int take, Dictionary<string, string> orderBy, string sortBy = null, bool isDescending = false)
                 => await repos.GetMeals(skip, take, orderBy, sortBy, isDescending);

        public async Task<MealDetailsDTO> GetMealDetails(int id)
               => await repos.GetMealDetails(id);


        public async Task<int> AddMealWithDetails(AddMealDTO input, string createdBy)
        {
            var transaction = await command.BeginTransactionAsync();
            try
            {
                var meal = new Meal
                {
                    Name = input.Name,
                    NameEn = string.IsNullOrEmpty(input.NameEn) ? input.Name : input.NameEn,
                    Description = input.Description,
                    DescriptionEn = string.IsNullOrEmpty(input.DescriptionEn) ? input.Description : input.DescriptionEn,
                    CreatedBy = createdBy,
                    IsAvailable = input.IsAvailable,
                    IsInMenu = input.IsInMenu,
                    Price = input.Price,
                    CategoryId = input.CategoryId is null or 0 ? 1 : input.CategoryId ?? 1
                };

                var result = await command.AddAsync(meal);

                if (input.MealItem.Any())
                {
                    var mealItem = new List<ItemMeal>();

                    foreach (var i in input.MealItem)
                    {
                        mealItem.Add(
                            new ItemMeal
                            {
                                ItemId = i.ItemId,
                                MealId = meal.Id,
                                QTY = i.QTY
                            });
                    }

                    var mealItemResult = await command.AddRangAsync(mealItem);
                }

                if (input.AddOnItemMeals.Any())
                {
                    var addOnMealMeals = new List<AddOnItemMeal>();

                    foreach (var addOn in input.AddOnItemMeals)
                    {
                        addOnMealMeals.Add(
                            new AddOnItemMeal
                            {
                                AddOnContainerId = addOn.AddOnContainerId,
                                MealId = meal.Id
                            });
                    }

                    await command.AddRangAsync(addOnMealMeals);

                }

                await transaction.CommitAsync();
                return meal.Id;

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message, ex);
            }


        }

        public async Task<int> UpdateMealWithDetails(UpdateMealDTO input, string lastModifiedBy, int mealId)
        {
            var transaction = await command.BeginTransactionAsync();
            try
            {
                var meal = await query.GetEntityAsync<Meal>(x => x.Id == mealId);

                meal.Name = input.Name ?? meal.Name;
                meal.NameEn = input.NameEn ?? meal.NameEn;
                meal.Description = input.Description ?? meal.Description;
                meal.DescriptionEn = input.DescriptionEn ?? meal.DescriptionEn;
                meal.IsAvailable = input.IsAvailable ?? meal.IsAvailable;
                meal.IsInMenu = input.IsInMenu ?? meal.IsInMenu;
                meal.Price = input.Price ?? meal.Price;
                meal.CategoryId = input.CategoryId ?? meal.CategoryId;
                meal.LastModifiedBy = lastModifiedBy;
                meal.LastModifiedDateTime = DateTime.Now;

                var result = await command.UpdateAsync(meal);

                if (input.MealItems.Any())
                {

                    var mealItems = new List<ItemMeal>();
                    foreach (var i in input.MealItems)
                    {
                        mealItems.Add(
                            new ItemMeal
                            {
                                ItemId = i.ItemId,
                                MealId = meal.Id,
                                QTY = i.QTY,
                            });
                    }

                    var mealItemsDb = await query.GetEntitiesAsync<ItemMeal>(x => x.MealId == meal.Id);

                    var willBeDeleted = mealItemsDb.ExceptBy(mealItems.Select(i => i.ItemId), x => x.ItemId);
                    var willBeAdded = mealItems.ExceptBy(mealItemsDb.Select(i => i.ItemId), x => x.ItemId);
                    if (willBeDeleted.Any())
                    {
                        await command.RemoveRangPermanentlyAsync(willBeDeleted);
                    }
                    if (willBeAdded.Any())
                    {
                        await command.AddRangAsync(willBeAdded);
                    }

                }

                if (input.AddOnItemMeals.Any())
                {
                    var addOnMeal = new List<AddOnItemMeal>();

                    foreach (var addOn in input.AddOnItemMeals)
                    {
                        addOnMeal.Add(
                            new AddOnItemMeal
                            {
                                AddOnContainerId = addOn.AddOnContainerId,
                                MealId = meal.Id
                            });
                    }
                    var addOnMealDb = await query.GetEntitiesAsync<AddOnItemMeal>(x => x.MealId == meal.Id);

                    var willBeDeleted = addOnMealDb.ExceptBy(addOnMeal.Select(i => i.AddOnContainerId), x => x.AddOnContainerId);
                    var willBeAdded = addOnMeal.ExceptBy(addOnMealDb.Select(i => i.AddOnContainerId), x => x.AddOnContainerId);
                    if (willBeDeleted.Any())
                    {
                        await command.RemoveRangPermanentlyAsync(willBeDeleted);
                    }
                    if (willBeAdded.Any())
                    {
                        await command.AddRangAsync(willBeAdded);
                    }

                }

                await transaction.CommitAsync();

                return result;

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message, ex);
            }


        }

        public async Task<int> UpdateMealImages(int mealId, List<ItemImagesDTO> inputs, string lastModifiedBy)
        {
            var meal = await query.GetEntityAsync<Meal>(x => x.Id == mealId);
            if (meal == null)
                throw new Exception("Meal not found");

            meal.LastModifiedBy = lastModifiedBy;
            meal.LastModifiedDateTime = DateTime.Now;

            var mediaMeal = new List<MediaItem>();
            foreach (var input in inputs)
            {
                mediaMeal.Add(new MediaItem
                {
                    MealId = meal.Id,
                    MediaId = input.imageId,
                    IsPrimary = input.IsPrimary
                });
            }

            var mediaMealDb = await query.GetEntitiesAsync<MediaItem>(x => x.MealId == meal.Id);


            var willBeDeleted = mediaMealDb
                     .ExceptBy(mediaMeal
                     .Select(i => new { i.MediaId, i.IsPrimary }), x => new { x.MediaId, x.IsPrimary });

            var willBeAdded = mediaMeal
                .ExceptBy(mediaMealDb
                .Select(i => new { i.MediaId, i.IsPrimary }), x => new { x.MediaId, x.IsPrimary });

            bool isFoundToDelete = willBeDeleted.Any();
            bool isFoundToAdd = willBeAdded.Any();


            if (isFoundToDelete)
            {
                await command.RemoveRangPermanentlyAsync(willBeDeleted);
            }
            if (isFoundToAdd)
            {

                await command.AddRangAsync(willBeAdded);
            }

            return isFoundToAdd || isFoundToDelete ? await command.UpdateAsync<Meal>(meal) : 0;
        }

        public async Task<int> RemoveMeal(int mealId, string lastModifiedBy)
        {
            var meal = await query.GetEntityAsync<Meal>(x => x.Id == mealId);
            meal.IsActive = false;
            meal.LastModifiedBy = lastModifiedBy;
            meal.LastModifiedDateTime = DateTime.Now;
            return await command.UpdateAsync(meal);
        }

        public async Task<int> BulkRemoveMeal(List<int> mealId, string lastModifiedBy)
        {
            var meals = await query.GetEntitiesAsync<Meal>(x => mealId.Contains(x.Id));
            foreach (var meal in meals)
            {
                meal.IsActive = false;
                meal.LastModifiedBy = lastModifiedBy;
                meal.LastModifiedDateTime = DateTime.Now;
            }

            return await command.UpdateRangAsync(meals);
        }

    }
}
