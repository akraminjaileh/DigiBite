using DigiBite_Core.Entities.Lookups;
using Microsoft.AspNetCore.Http;

namespace DigiBite_Core.IServices
{
    public interface IMediaService
    {
        Task RemoveFile(int mediaId);
        Task<List<Media>> UploadFiles(IFormFileCollection files, string uploadedBy);
        Task<Media> UploadFile(IFormFile file, string uploadedBy);
    }
}
