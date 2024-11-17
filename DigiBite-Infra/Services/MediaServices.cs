using DigiBite_Core.DTOs.Media;
using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using Microsoft.AspNetCore.Http;

namespace DigiBite_Infra.Services
{
    public class MediaServices(IMediaRepos repos) : IMediaService
    {
        public async Task<string> GetFileUrlById(int id)
                 => await repos.GetFileUrlById(id);

        public async Task<List<MediasDTO>> GetFiles(int skip, int take)
                 => await repos.GetFiles(skip, take);

        public async Task<int> UploadFiles(IFormFileCollection files, string uploadedBy)
                  => await repos.UploadFiles(files, uploadedBy);
        public async Task<int> RemoveFile(int mediaId) => await repos.RemoveFile(mediaId);

        public async Task<int> BulkRemoveFile(List<int> ids)
            => await repos.BulkRemoveFile(ids);

        public async Task<int> UpdateFile(int id, MediaUpdateDTO input)
            => await repos.UpdateFile(id, input);

        //User Profile Image
        public async Task<Media> UploadProfileImage(IFormFile file, string uploadedBy)
                  => await repos.UploadProfileImage(file, uploadedBy);
    }
}
