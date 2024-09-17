using Microsoft.AspNetCore.Mvc.Filters;

namespace DigiBite_Core.Filters
{
    public class ResponseFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var t = 9;
            await next();
            var xx = context.HttpContext.Response;
        
        }
    }
}
