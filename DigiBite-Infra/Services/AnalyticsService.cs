using DigiBite_Core.DTOs.Analytics;
using DigiBite_Core.IRepos;
using DigiBite_Core.IServices;

namespace DigiBite_Infra.Services
{
    public class AnalyticsService(IAnalyticsRepos repos) : IAnalyticsService
    {
        public async Task<IEnumerable<SalesDataDTO>> GetDailySales()
           => await repos.GetDailySales();

        public async Task<IEnumerable<SalesDataDTO>> GetMonthlySales()
           => await repos.GetMonthlySales();

    }
}
