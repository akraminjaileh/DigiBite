using DigiBite_Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DigiBite_Core.Filter
{
    public class ApiResponseFilter : IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // No implementation needed.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                if (objectResult.StatusCode >= 200 && objectResult.StatusCode < 300)
                {
                    context.Result = new ObjectResult(new ApiResponse<object>(objectResult.Value))
                    {
                        StatusCode = objectResult.StatusCode
                    };
                }
                else
                {

                    context.Result = new ObjectResult(new ApiResponse<object>(objectResult.Value?.ToString() ?? "An error occurred"))
                    {
                        StatusCode = objectResult.StatusCode
                    };
                }
            }
        }

    }
}