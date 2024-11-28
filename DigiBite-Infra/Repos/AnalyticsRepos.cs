using DigiBite_Core.Context;
using DigiBite_Core.DTOs.Analytics;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Repos
{
    public class AnalyticsRepos(DigiBiteContext context) : IAnalyticsRepos
    {
        #region Order Analytics

        public async Task<IEnumerable<SalesDataDTO>> GetDailySales()
        {
            try
            {
                return await context.Orders
                       .Where(o => o.CreationDateTime >= DateTime.Now.AddDays(-30))
                       .Join(context.Carts,
                             o => o.CartId,
                             c => c.Id,
                             (o, c) => new { o.CreationDateTime, c.TotalAmount })
                           .GroupBy(x => new { x.CreationDateTime.Month, x.CreationDateTime.Day })
                           .Select(g => new SalesDataDTO
                           {
                               Label = new DateTime(g.Key.Month, g.Key.Day, 1).ToString("dd-MM"),
                               TotalSales = g.Sum(x => x.TotalAmount)
                           }
                       ).ToListAsync();
                
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<SalesDataDTO>> GetMonthlySales()
        {
            try
            {
                return await context.Orders
                        .Where(o => o.CreationDateTime >= DateTime.Now.AddMonths(-12))
                        .Join(context.Carts,
                              o => o.CartId,
                              c => c.Id,
                              (o, c) => new { o.CreationDateTime, c.TotalAmount })
                            .GroupBy(x => new { x.CreationDateTime.Year, x.CreationDateTime.Month })
                            .Select(g => new SalesDataDTO
                            {
                                Label = new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMMM yyyy"), // Convert back to desired string format
                                TotalSales = g.Sum(x => x.TotalAmount)
                            }
                        ).ToListAsync();

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion
    }
}
