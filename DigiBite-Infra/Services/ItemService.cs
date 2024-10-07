using DigiBite_Core.DTOs.Item;
using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using DigiBite_Core.Models.ManyToMany;

namespace DigiBite_Infra.Services
{
    public class ItemService(IItemRepos repos, ICommandRepos command, IQueryRepos query) : IItemService
    {

        public async Task<IEnumerable<ItemsDTO>> GetItems(int skip, int take, Dictionary<string, string> orderBy, string sortBy = null, bool isDescending = false)
                 => await repos.GetItems(skip, take, orderBy, sortBy, isDescending);

        public async Task<ItemDetailsDTO> GetItemDetails(int id)
               => await repos.GetItemDetails(id);


        public async Task<int> AddItemWithDetails(AddItemDTO input, string createdBy)
        {
            var transaction = await command.BeginTransactionAsync();
            try
            {
                var item = new Item
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

                var result = await command.AddAsync(item);

                if (input.ItemIngredients.Any())
                {
                    var itemIngredients = new List<ItemIngredient>();

                    foreach (var ing in input.ItemIngredients)
                    {
                        itemIngredients.Add(
                            new ItemIngredient
                            {
                                IngredientId = ing.IngredientId,
                                ItemId = item.Id,
                                QTY = ing.QTY,
                            });
                    }

                    var itemIngResult = await command.AddRangAsync(itemIngredients);
                }

                if (input.AddOnItemMeals.Any())
                {
                    var addOnItemMeals = new List<AddOnItemMeal>();

                    foreach (var addOn in input.AddOnItemMeals)
                    {
                        addOnItemMeals.Add(
                            new AddOnItemMeal
                            {
                                AddOnContainerId = addOn.AddOnContainerId,
                                ItemId = item.Id
                            });
                    }

                    await command.AddRangAsync(addOnItemMeals);

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

        public async Task<int> UpdateItemWithDetails(UpdateItemDTO input, string lastModifiedBy, int itemId)
        {
            var transaction = await command.BeginTransactionAsync();
            try
            {
                var item = await query.GetEntityAsync<Item>(x => x.Id == itemId);

                item.Name = input.Name ?? item.Name;
                item.NameEn = input.NameEn ?? item.NameEn;
                item.Description = input.Description ?? item.Description;
                item.DescriptionEn = input.DescriptionEn ?? item.DescriptionEn;
                item.IsAvailable = input.IsAvailable ?? item.IsAvailable;
                item.IsInMenu = input.IsInMenu ?? item.IsInMenu;
                item.Price = input.Price ?? item.Price;
                item.CategoryId = input.CategoryId ?? item.CategoryId;
                item.LastModifiedBy = lastModifiedBy;
                item.LastModifiedDateTime = DateTime.UtcNow;

                var result = await command.UpdateAsync(item);

                if (input.ItemIngredients.Any())
                {

                    var itemIngredients = new List<ItemIngredient>();
                    foreach (var ing in input.ItemIngredients)
                    {
                        itemIngredients.Add(
                            new ItemIngredient
                            {
                                IngredientId = ing.IngredientId,
                                ItemId = item.Id,
                                QTY = ing.QTY,
                            });
                    }

                    var itemIngredientsDb = await query.GetEntitiesAsync<ItemIngredient>(x => x.ItemId == item.Id);

                    var willBeDeleted = itemIngredientsDb.ExceptBy(itemIngredients.Select(i => i.IngredientId), x => x.IngredientId);
                    var willBeAdded = itemIngredients.ExceptBy(itemIngredientsDb.Select(i=>i.IngredientId),x=> x.IngredientId);
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
                    var addOnItemMeals = new List<AddOnItemMeal>();

                    foreach (var addOn in input.AddOnItemMeals)
                    {
                        addOnItemMeals.Add(
                            new AddOnItemMeal
                            {
                                AddOnContainerId = addOn.AddOnContainerId,
                                ItemId = item.Id
                            });
                    }
                    var addOnItemMealsDb = await query.GetEntitiesAsync<AddOnItemMeal>(x => x.ItemId == item.Id);

                    var willBeDeleted = addOnItemMealsDb.ExceptBy(addOnItemMeals.Select(i=>i.AddOnContainerId),x=>x.AddOnContainerId);
                    var willBeAdded = addOnItemMeals.ExceptBy(addOnItemMealsDb.Select(i => i.AddOnContainerId), x => x.AddOnContainerId);
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


        public async Task<int> RemoveItem(int itemId, string lastModifiedBy)
        {
            var item = await query.GetEntityAsync<Item>(x => x.Id == itemId);
            item.IsActive = false;
            item.LastModifiedBy = lastModifiedBy;
            item.LastModifiedDateTime = DateTime.UtcNow;
            return await command.UpdateAsync(item);
        }

        public async Task<int> BulkRemoveItem(List<int> itemId, string lastModifiedBy)
        {
            var items = await query.GetEntitiesAsync<Item>(x => itemId.Contains(x.Id));
            foreach (var item in items)
            {
                item.IsActive = false;
                item.LastModifiedBy = lastModifiedBy;
                item.LastModifiedDateTime = DateTime.UtcNow; 
            }

            return await command.UpdateRangAsync(items);
        }

    }
}
