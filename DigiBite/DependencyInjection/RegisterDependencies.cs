using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;
using DigiBite_Infra.Repos;
using DigiBite_Infra.Services;

namespace DigiBite_Api.Configurations
{
    public static class RegisterDependencies
    {
        public static void AddMultiScoped(this IServiceCollection services)
        {
            services.AddScoped<ICommandRepos, CommandRepos>();

            services.AddScoped<IItemRepos, ItemRepos>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IMediaRepos, MediaRepos>();
            
        }
    }
}
