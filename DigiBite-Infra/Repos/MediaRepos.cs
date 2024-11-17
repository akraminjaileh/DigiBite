using DigiBite_Core.Constant;
using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Media;
using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.IRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DigiBite_Infra.Repos
{
    public class MediaRepos(DigiBiteContext context) : IMediaRepos
    {

        public async Task<List<MediasDTO>> GetFiles(int skip, int take)
        {
            try
            {
                var query = from m in context.Medias
                            .Skip(skip).Take(take == 0 ? 20 : take)
                             orderby m.UploadedOn descending
                            select new MediasDTO
                            {
                                Id = m.Id,
                                FileName = m.FileName,
                                ImageUrl = m.ImageUrl,
                                AltText = m.AltText,
                                SizeKB = m.SizeKB,
                                FileType = m.FileType.ToString(),
                                UploadedBy = m.UploadedBy,
                                UploadedOn = m.UploadedOn
                            };
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> GetFileUrlById(int id)
        {
            try
            {
                var file = await context.Medias.FirstOrDefaultAsync(x => x.Id == id);
                if (file == null)
                {
                    return string.Empty;
                }

                return file.ImageUrl;

            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while getting the file: {ex.Message}", ex);
            }
        }

        public async Task<int> UploadFiles(IFormFileCollection files, string uploadedBy)
        {

            var transaction = await context.Database.BeginTransactionAsync();

            try
            {

                if (files.IsNullOrEmpty())
                {
                    throw new Exception("No selected files");
                }

                var fileList = new List<Media>();
                var supportedFileTypes = string.Join(", ", Enum.GetNames<FileType>());

                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
                // Ensure the directory exists
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                foreach (var file in files)
                {
                    var fileExtension = Path.GetExtension(file.FileName).ToLower().TrimStart('.');

                    if (!Enum.TryParse<FileType>(fileExtension, out var fileType))
                    {
                        throw new Exception($"The file '{file.FileName}' is not supported. " +
                                           $"Please choose one of these formats: {supportedFileTypes}. ");
                    }

                    if (file.Length > 10485760)
                    {
                        throw new Exception($"The file '{file.FileName}' exceeds the maximum allowed size of 10MB. ");
                    }

                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
                    var pathOnDb = $"{Guid.NewGuid()}{file.FileName}";
                    var fullPath = Path.Combine(directory, pathOnDb);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var media = new Media
                    {
                        FileType = fileType,
                        FileName = fileNameWithoutExtension,
                        AltText = fileNameWithoutExtension,
                        ImageUrl = pathOnDb,
                        SizeKB = (int)file.Length / 1024,
                        UploadedBy = uploadedBy
                    };

                    fileList.Add(media);
                }

                context.Medias.AddRange(fileList);
                var result = await context.SaveChangesAsync();
                await transaction.CommitAsync();

                return result;

            }
            catch (IOException ioEx)
            {
                await transaction.RollbackAsync();
                throw new Exception($"An error occurred during file upload: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }

        }


        public async Task<int> RemoveFile(int id)
        {

            try
            {
                var file = await context.Medias.FirstOrDefaultAsync(x => x.Id == id);
                if (file == null)
                {
                    return 0;
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", file.ImageUrl);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                context.Medias.Remove(file);
                return await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while removing the file: {ex.Message}", ex);
            }
        }

        public async Task<int> BulkRemoveFile(List<int> ids)
        {

            try
            {
                var files = await context.Medias
                 .Where(x => ids.Contains(x.Id))
                 .ToListAsync();

                if (files.IsNullOrEmpty())
                {
                    return 0;
                }

                foreach (var file in files)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", file.ImageUrl);

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
                context.Medias.RemoveRange(files);
                return await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while removing the file: {ex.Message}", ex);
            }
        }


        public async Task<int> UpdateFile(int id, MediaUpdateDTO input)
        {
            try
            {
                var file = await context.Medias.FirstOrDefaultAsync(x => x.Id == id);
                if (file == null) throw new Exception("File Not Found");
                file.FileName = input.FileName ?? file.FileName;
                file.AltText = input.AltText ?? file.AltText;
                context.Update(file);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        //User Profile Image
        public async Task<Media> UploadProfileImage(IFormFile file, string uploadedBy)
        {

            var transaction = await context.Database.BeginTransactionAsync();

            try
            {

                if (file == null)
                {
                    throw new Exception("No selected file");
                }

                var supportedFileTypes = string.Join(", ", Enum.GetNames<FileType>());

                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
                // Ensure the directory exists
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var fileExtension = Path.GetExtension(file.FileName).ToLower().TrimStart('.');

                if (!Enum.TryParse<FileType>(fileExtension, out var fileType))
                {
                    throw new Exception($"The file '{file.FileName}' is not supported. " +
                                       $"Please choose one of these formats: {supportedFileTypes}. ");
                }

                if (file.Length > 10485760)
                {
                    throw new Exception($"The file '{file.FileName}' exceeds the maximum allowed size of 10MB. ");
                }

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
                var pathOnDb = $"{Guid.NewGuid()}{file.FileName}";
                var fullPath = Path.Combine(directory, pathOnDb);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var media = new Media
                {
                    FileType = fileType,
                    FileName = fileNameWithoutExtension,
                    AltText = fileNameWithoutExtension,
                    ImageUrl = pathOnDb,
                    SizeKB = (int)file.Length / 1024,
                    UploadedBy = uploadedBy
                };

                context.Medias.Add(media);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                return media;

            }
            catch (IOException ioEx)
            {
                await transaction.RollbackAsync();
                throw new Exception($"An error occurred during file upload: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }

        }


    }
}
