using DigiBite_Core.DTOs.Item;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Services
{
    public class ItemService(IItemRepos repos, IQueryRepos query) : IItemService
    {
        public async Task<IEnumerable<ItemDTO>> GetItems()
        {
            var items = await query.GetAll<Item, Category, int, ItemDTO>(
                i => i.CategoryId,
                c => c.Id,
                (i, c) =>
                new ItemDTO
                {
                    Name = i.Name,
                    Price = i.Price,
                    IsAvailable = i.IsAvailable,
                    CategoryName = c.Name,

                }
            ).Take(8).ToListAsync();
            return items;

        }
    }
}
