using DigiBite_Core.DTOs.Media;
using DigiBite_Core.Entities.Lookups;
using Microsoft.AspNetCore.Http;

namespace DigiBite_Core.IRepos
{
    public interface IMediaRepos
    {
        Task<int> RemoveFile(int id);
        Task<int> UploadFiles(IFormFileCollection files, string uploadedBy);
        Task<string> GetFileUrlById(int id);
        Task<List<MediasDTO>> GetFiles(int skip, int take);
        Task<int> BulkRemoveFile(List<int> ids);
        Task<int> UpdateFile(int id, MediaUpdateDTO input);
        Task<Media> UploadProfileImage(IFormFile file, string uploadedBy);
    }
}
