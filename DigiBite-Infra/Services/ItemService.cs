using DigiBite_Core.DTOs.Item;
using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using DigiBite_Core.Models.ManyToMany;

namespace DigiBite_Infra.Services
{
    public class ItemService(IItemRepos repos, ICommandRepos command) : IItemService
    {
        public async Task<IEnumerable<ItemsDTO>> GetItems(int skip, int take, Dictionary<string, string> orderBy, string sortBy = null, bool isDescending = false)
        {
            return await repos.GetItems(skip, take, orderBy, sortBy, isDescending);


        }

        public async Task<ItemDetailsDTO> GetItemDetails(int id)
        {
            return await repos.GetItemDetails(id);
        }

        public async Task<int> AddItemWithDetails(AddItemDTO input)
        {
            return await command.AddAsync(input);
        }

        public async Task<int> AddItemWithDetails(AddItemDTO input, string createdBy)
        {
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
                    CategoryId = input.CategoryId ?? 1
                };

                var itemResult = await command.AddAsync(item);

                if (itemResult == 0)
                    throw new Exception("Failed to create item");

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

                    if (itemIngResult == 0)
                        throw new Exception("Failed to Add Ingredients to the Item");
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

                    var addOnResult = await command.AddRangAsync(addOnItemMeals);

                    if (addOnResult == 0)
                        throw new Exception("Failed to Add AddOns to the Item");
                }


                return 1;

            }
            catch (Exception ex)
            {
                return 1;

            }
        }
    }
}
