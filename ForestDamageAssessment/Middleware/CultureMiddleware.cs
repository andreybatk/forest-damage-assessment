using System.Globalization;

namespace ForestDamageAssessment.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
                CultureInfo.CurrentUICulture = new CultureInfo("ru-RU");
            }
            catch (CultureNotFoundException) { }
            await _next.Invoke(context);
        }
    }
}
