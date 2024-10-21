using DigiBite_Core.DTOs.AddOn;
using DigiBite_Core.DTOs.AddOnContainer;

namespace DigiBite_Core.IRepos
{
    public interface IAddOnRepos
    {
        Task<AddOnContainerDTO> GetAddOnContainerById(int id);
        Task<IEnumerable<AddOnContainersDTO>> GetAddOnContainers(int skip, int take, string sortBy = null, bool isDescending = false);
    }
}
