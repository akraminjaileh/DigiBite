using DigiBite_Core.Context;
using DigiBite_Core.DTOs.AddOn;
using DigiBite_Core.DTOs.AddOnContainer;
using DigiBite_Core.Extension;
using DigiBite_Core.Helpers;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Repos
{
    public class AddOnRepos(DigiBiteContext context) : IAddOnRepos
    {
        public async Task<IEnumerable<AddOnContainersDTO>> GetAddOnContainers(
            int skip, int take,
            string sortBy = null, bool isDescending = false)
        {
            var query = from addOn in context.AddOnContainers
                        .Where(a=>a.IsActive == true)
                        .ApplyFilterAndSort(null, sortBy, isDescending)
                        .Skip(skip)
                        .Take(take > 0 ? take : 20)
                        select new AddOnContainersDTO
                        {
                            Id = addOn.Id,
                            Name = LanguageService.SelectLang(addOn.Name, addOn.NameEn)
                        };
            return await query.ToListAsync();
        }


        public async Task<AddOnContainerDTO> GetAddOnContainerById(int id)
        {
            var query = from addOn in context.AddOnContainers
                        .Where(a => a.Id == id && a.IsActive == true)
                        select new AddOnContainerDTO
                        {
                            Id = addOn.Id,
                            Name = LanguageService.SelectLang(addOn.Name, addOn.NameEn),
                            Addons = (from a in context.AddOns
                                      where a.AddOnContainerId == addOn.Id && a.IsActive == true
                                      select new AddOnDTO
                                      {
                                          Id = a.Id,
                                          Name = LanguageService.SelectLang(a.Name, a.NameEn),
                                          Price = a.Price,
                                          ImageUrl = (from img in context.Medias
                                                      where a.ImageId == img.Id
                                                      select img.ImageUrl).SingleOrDefault()
                                      }).ToList()
                        };
            var addon = await query.FirstOrDefaultAsync();
            return addon != null ? addon : throw new Exception("AddOn not found");
        }


    }
}
