using Microsoft.AspNetCore.Http;

namespace DigiBite_Core.IServices
{
    public interface IMediaService
    {
        Task<int> UploadFiles(IFormFileCollection files, string UploadedBy);
    }
}
