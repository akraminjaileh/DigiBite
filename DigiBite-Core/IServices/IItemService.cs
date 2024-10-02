using DigiBite_Core.DTOs.Category;
using DigiBite_Core.DTOs.Item;

namespace DigiBite_Core.IServices
{
    public interface IItemService
    {
        Task<ItemDetailsDTO> GetItemDetails(int id);
        Task<IEnumerable<ItemsDTO>> GetItems(int skip, int take, Dictionary<string, string> orderBy, string sortBy = null, bool isDescending = false);

    }
}
