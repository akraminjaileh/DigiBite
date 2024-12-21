using DigiBite_Core.DTOs.Item;
using DigiBite_Core.Helpers;

namespace DigiBite_Core.IRepos
{
    public interface IItemRepos
    {
        Task<ItemDetailsDTO> GetItemDetails(int id);
        Task<PaginatedResult<ItemsDTO>> GetItems(int skip, int take, Dictionary<string, string> orderBy, string sortBy, bool isDescending);
    }
}
