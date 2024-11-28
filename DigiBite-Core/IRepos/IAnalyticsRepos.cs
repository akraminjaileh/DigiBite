using DigiBite_Core.DTOs.Analytics;

namespace DigiBite_Core.IRepos
{
    public interface IAnalyticsRepos
    {
        Task<IEnumerable<SalesDataDTO>> GetDailySales();
        Task<IEnumerable<SalesDataDTO>> GetMonthlySales();
    }
}
