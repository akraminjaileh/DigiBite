using DigiBite_Core.DTOs.Item;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;

namespace DigiBite_Infra.Services
{
    public class ItemService(IItemRepos repos) : IItemService
    {
        public async Task<IEnumerable<ItemsDTO>> GetItems(int skip, int take)
        {
            return new List<ItemsDTO>();

        }


    }
}
