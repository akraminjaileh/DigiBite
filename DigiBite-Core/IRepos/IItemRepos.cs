using DigiBite_Core.DTOs.Item;
using DigiBite_Core.Models.Entities;

namespace DigiBite_Core.IRepos
{
    public interface IItemRepos
    {
        Task<ItemDetailsDTO> GetItemDetails(int id);
        Task<IEnumerable<ItemsDTO>> GetItems(int skip, int take, Dictionary<string, string> orderBy, string sortBy, bool isDescending);
    }
}
