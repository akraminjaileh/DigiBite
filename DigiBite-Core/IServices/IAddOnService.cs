using DigiBite_Core.DTOs.AddOn;
using DigiBite_Core.DTOs.AddOnContainer;

namespace DigiBite_Core.IServices
{
    public interface IAddOnService
    {
        Task<int> BulkRemoveAddOnContainer(List<int> containerIDs, string lastModifiedBy);
        Task<int> CreateContainerWithAddOn(CreateContainerWithAddOnDTO input, string createdBy);
        Task<AddOnContainerDTO> GetAddOnContainerById(int id);
        Task<IEnumerable<AddOnContainersDTO>> GetAddOnContainers(int skip, int take, string sortBy = null, bool isDescending = false);
        Task<int> NewAddOn(int containerId, NewAddOnDTO input, string createdBy);
        Task<int> RemoveAddOn(int id, string modifiedBy);
        Task<int> RemoveAddOnContainer(int id, string modifiedBy);
        Task<int> UpdateAddOnImage(int addonId, int imageId, string lastModifiedBy);
        Task<int> UpdateContainer(int id, UpdateContainerDTO input, string modifiedBy);
    }
}
