using DigiBite_Core.DTOs.Item;

namespace DigiBite_Core.IServices
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetItems(int skip, int take);
    }
}
