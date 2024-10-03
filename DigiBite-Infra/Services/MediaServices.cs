using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Http;

namespace DigiBite_Infra.Services
{
    public class MediaServices(IMediaRepos repos) : IMediaService
    {
        public async Task<int> UploadFiles(IFormFileCollection files, string UploadedBy)
        {

            return await repos.UploadFiles(files, UploadedBy);

        }

    }
}
