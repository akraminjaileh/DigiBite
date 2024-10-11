using DigiBite_Core.Entities.Lookups;
using Microsoft.AspNetCore.Http;

namespace DigiBite_Core.IRepos
{
    public interface IMediaRepos
    {
        Task RemoveFile(int id);
        Task<List<Media>> UploadFiles(IFormFileCollection files, string uploadedBy);
        Task<Media> UploadFile(IFormFile file, string uploadedBy);
        Task<string> GetFileUrlById(int id);
    }
}
