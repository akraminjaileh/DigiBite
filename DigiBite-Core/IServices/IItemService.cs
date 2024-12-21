using DigiBite_Core.DTOs.Item;
using DigiBite_Core.Helpers;

namespace DigiBite_Core.IServices
{
    public interface IItemService
    {

        Task<PaginatedResult<ItemsDTO>> GetItems(int skip, int take, Dictionary<string, string> orderBy, string sortBy = null, bool isDescending = false);
        Task<ItemDetailsDTO> GetItemDetails(int id);
        Task<int> AddItemWithDetails(AddItemDTO input, string createdBy);
        Task<int> UpdateItemWithDetails(UpdateItemDTO input, string lastModifiedBy, int itemId);
        Task<int> RemoveItem(int itemId, string lastModifiedBy);
        Task<int> BulkRemoveItem(List<int> itemId, string lastModifiedBy);
        Task<int> UpdateItemImages(int itemId, List<ItemImagesDTO> inputs, string lastModifiedBy);
    }
}
