using DigiBite_Core.IRepos;
using DigiBite_Infra.Repos;

namespace DigiBite_Api.Configurations
{
    public static class RegisterDependencies
    {
        public static void AddMultiScoped(this IServiceCollection services)
        {
            services.AddScoped<IQueryRepos, QueryRepos>();
            services.AddScoped<ICommandRepos, CommandRepos>();
        }
    }
}
