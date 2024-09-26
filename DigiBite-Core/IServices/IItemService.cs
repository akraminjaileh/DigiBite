using DigiBite_Core.DTOs.Category;
using DigiBite_Core.DTOs.Item;

namespace DigiBite_Core.IServices
{
    public interface IItemService
    {
        //Task<IEnumerable<ItemsDTO>> GetItems(int skip, int take , Predicate<ItemsDTO> predicate);
        //Task<IEnumerable<ItemsDTO>> GetItems(int skip, int take, object orderBySelector);
        //Task<IEnumerable<ItemsDTO>> GetItems(int skip, int take, object orderBySelector);
        Task<IEnumerable<ItemsDTO>> GetItems(int skip, int take);
        //IEnumerable<CategoryDTO> GetItems(int skip, int take);
    }
}
