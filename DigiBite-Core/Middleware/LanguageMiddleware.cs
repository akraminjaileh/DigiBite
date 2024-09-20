using DigiBite_Core.Helpers;
using Microsoft.AspNetCore.Http;

namespace DigiBite_Core.Middleware
{
    public class LanguageMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            bool result = context.Request.Headers.TryGetValue("Accept-Language", out var language);

            if (result && language.ToString().Equals("en"))
                LanguageService.Lang = language.ToString();
            else
                LanguageService.Lang = "ar";  //Arabic is a default value

            await next(context);
        }
    }
}