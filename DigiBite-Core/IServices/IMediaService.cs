using DigiBite_Core.DTOs.Media;
using DigiBite_Core.Entities.Lookups;
using Microsoft.AspNetCore.Http;

namespace DigiBite_Core.IServices
{
    public interface IMediaService
    {
        Task<int> BulkRemoveFile(List<int> ids);
        Task<List<MediasDTO>> GetFiles(int skip, int take);
        Task<string> GetFileUrlById(int id);
        Task<int> RemoveFile(int mediaId);
        Task<int> UpdateFile(int id, MediaUpdateDTO input);
        Task<int> UploadFiles(IFormFileCollection files, string uploadedBy);
        Task<Media> UploadProfileImage(IFormFile file, string uploadedBy);
    }
}
