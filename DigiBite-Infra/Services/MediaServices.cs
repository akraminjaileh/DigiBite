using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Http;

namespace DigiBite_Infra.Services
{
    public class MediaServices(IMediaRepos repos) : IMediaService
    {

        public async Task RemoveFile(int mediaId) => await repos.RemoveFile(mediaId);


        public async Task<Media> UploadFile(IFormFile file, string uploadedBy)
                   => await repos.UploadFile(file, uploadedBy);

        public async Task<List<Media>> UploadFiles(IFormFileCollection files, string uploadedBy)
                  => await repos.UploadFiles(files, uploadedBy);


    }
}
