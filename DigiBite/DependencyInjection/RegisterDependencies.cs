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
            services.AddScoped<IQueryRepos, QueryRepos>();

            services.AddScoped<IItemRepos, ItemRepos>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IMediaRepos, MediaRepos>();
            services.AddScoped<IMediaService, MediaServices>();
            services.AddScoped<IMealRepos, MealRepos>();
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<ICategoryRepos, CategoryRepos>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IIngredientRepos, IngredientRepos>();
            services.AddScoped<IAddOnService, AddOnService>();
            services.AddScoped<IAddOnRepos, AddOnRepos>();
            services.AddScoped<ICustomerActionRepos, CustomerActionRepos>();
            services.AddScoped<ICustomerActionService, CustomerActionService>();

        }
    }
}
