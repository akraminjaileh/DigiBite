using DigiBite_Core.Constant;
using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Media;
using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.IRepos;
using Microsoft.AspNetCore.Http;

namespace DigiBite_Infra.Repos
{
    public class MediaRepos(DigiBiteContext context) : IMediaRepos
    {
        public async Task<int> UploadFiles(IFormFileCollection files, string UploadedBy)
        {
            var fileList = new List<Media>();
           
            foreach (var file in files)
            {

                var fileExtension = file.FileName.Split('.').Last().ToLower();

                //Check if file is Supported
                bool isSupport = Enum.TryParse<FileType>(fileExtension, out FileType fileType);
                if(!isSupport)
                    throw new Exception($"The file:'{file.FileName}' is not supported. " +
                        $"Please choose one of these formats: {string.Join(", ", Enum.GetNames<FileType>())}");

                // Check File Size Max 10 MB (10,485,760 byte)
                if (file.Length > 10485760)
                    throw new Exception($"The file '{file}' exceeds the maximum allowed size of 10MB.");


                var fileName = file.FileName.Split($".{fileExtension}").First();
                var directory =Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
                var pathOnDb = $"{Guid.NewGuid}{file.FileName}";
                var fullPath = Path.Combine(directory, pathOnDb);
                try
                {
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await stream.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An unexpected error occurred while uploading the file.", ex);
                }
               

                fileList.Add(new Media
                {
                    FileType = fileType,
                    FileName = fileName,
                    AltText = fileName,
                    IsPrimary = false,
                    ImageUrl = pathOnDb,
                    SizeKB = (int)file.Length / 1024,
                    UploadedBy = UploadedBy
                });
            }

            context.Medias.AddRange(fileList);
            return await context.SaveChangesAsync();
            

        }


    }
}
