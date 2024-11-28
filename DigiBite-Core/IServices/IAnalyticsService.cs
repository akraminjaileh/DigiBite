using DigiBite_Core.DTOs.Analytics;

namespace DigiBite_Core.IServices
{
    public interface IAnalyticsService
    {
        Task<IEnumerable<SalesDataDTO>> GetDailySales();
        Task<IEnumerable<SalesDataDTO>> GetMonthlySales();
    }
}
