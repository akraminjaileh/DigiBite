using DigiBite_Core.DTOs.Item;
using DigiBite_Core.Helpers;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Services
{
    public class ItemService(IItemRepos repos, IQueryRepos query) : IItemService
    {
        public async Task<IEnumerable<ItemDTO>> GetItems(int skip, int take)
        {

            var items = await query.GetProjected<Item, Category, int, ItemDTO>(
                i => i.CategoryId,
                c => c.Id,
                (i, c) =>
                new ItemDTO
                {
                    Name =LanguageService.SelectLang(i.Name,i.NameEn),
                    Price = i.Price,
                    IsAvailable = i.IsAvailable,
                    CategoryName = LanguageService.SelectLang(c.Name,c.NameEn),

                }
            ).Skip(skip == 0 ? 0 : skip).Take(take == 0 ? 5 : take).AsNoTracking().ToListAsync();
            return items;

        }
    }
}
