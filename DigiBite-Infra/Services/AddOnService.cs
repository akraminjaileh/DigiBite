using DigiBite_Core.DTOs.AddOn;
using DigiBite_Core.DTOs.AddOnContainer;
using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;

namespace DigiBite_Infra.Services
{
    public class AddOnService(IAddOnRepos repos, ICommandRepos command, IQueryRepos query) : IAddOnService
    {
        public async Task<IEnumerable<AddOnContainersDTO>> GetAddOnContainers(int skip, int take,
           string sortBy = null, bool isDescending = false)
                => await repos.GetAddOnContainers(skip, take, sortBy, isDescending);

        public async Task<AddOnContainerDTO> GetAddOnContainerById(int id)
               => await repos.GetAddOnContainerById(id);

        public async Task<int> CreateContainerWithAddOn(CreateContainerWithAddOnDTO input, string createdBy)
        {
            var transaction = await command.BeginTransactionAsync();
            try
            {
                var addonContainer = new AddOnContainer
                {
                    Name = input.Name,
                    NameEn = string.IsNullOrEmpty(input.NameEn) ? input.Name : input.NameEn,
                    CreatedBy = createdBy
                };

                await command.AddAsync(addonContainer);

                var addon = new List<AddOn>();
                foreach (var a in input.AddOns)
                {
                    addon.Add(new AddOn
                    {
                        Name = a.Name,
                        NameEn = string.IsNullOrEmpty(a.NameEn) ? a.Name : a.NameEn,
                        AddOnContainerId = addonContainer.Id,
                        CreationDateTime = DateTime.Now,
                        Price = a.Price,
                        ImageId = a.ImageId,
                        CreatedBy = createdBy
                    });
                }

                var result = await command.AddRangAsync(addon);
                await transaction.CommitAsync();
                return result;

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateContainer(int id, UpdateContainerDTO input, string modifiedBy)
        {
            try
            {
                var container = await query.GetEntityAsync<AddOnContainer>(x => x.Id == id);
                container.Name = input.Name ?? container.Name;
                container.NameEn = input.NameEn ?? container.NameEn;
                container.LastModifiedBy = modifiedBy;
                container.LastModifiedDateTime = DateTime.Now;
                return await command.UpdateAsync(container);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> NewAddOn(int containerId, NewAddOnDTO input, string createdBy)
        {
            try
            {
                var addonContainer = await query.GetEntityAsync<AddOnContainer>(x => x.Id == containerId);

                var addon = new AddOn
                {
                    Name = input.Name,
                    NameEn = input.NameEn,
                    AddOnContainerId = addonContainer.Id,
                    CreationDateTime = DateTime.Now,
                    Price = input.Price,
                    ImageId = input.ImageId,
                    CreatedBy = createdBy
                };
                return await command.AddAsync(addon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> RemoveAddOn(int id, string modifiedBy)
        {
            try
            {
                var addon = await query.GetEntityAsync<AddOn>(x => x.Id == id);
                addon.IsActive = false;
                addon.LastModifiedBy = modifiedBy;
                addon.LastModifiedDateTime = DateTime.Now;
                return await command.UpdateAsync(addon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<int> UpdateAddOnImage(int addonId, int imageId, string lastModifiedBy)
        {
            if (!(imageId > 0)) return 0;

            var addon = await query.GetEntityAsync<AddOn>(x => x.Id == addonId);
            if (addon == null)
                throw new Exception("AddOn not found");

            addon.LastModifiedBy = lastModifiedBy;
            addon.LastModifiedDateTime = DateTime.Now;
            addon.ImageId = imageId;
            return await command.UpdateAsync(addon);

        }

        public async Task<int> RemoveAddOnContainer(int id, string modifiedBy)
        {
            try
            {
                var container = await query.GetEntityAsync<AddOnContainer>(x => x.Id == id);

                container.IsActive = false;
                container.LastModifiedBy = modifiedBy;
                container.LastModifiedDateTime = DateTime.Now;

                return await command.UpdateAsync(container);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> BulkRemoveAddOnContainer(List<int> containerIDs, string lastModifiedBy)
        {
            var containers = await query.GetEntitiesAsync<AddOnContainer>(x => containerIDs.Contains(x.Id));
            foreach (var c in containers)
            {
                c.IsActive = false;
                c.LastModifiedBy = lastModifiedBy;
                c.LastModifiedDateTime = DateTime.Now;
            }

            return await command.UpdateRangAsync(containers);
        }

    }
}
