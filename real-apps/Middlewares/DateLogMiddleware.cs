using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace real_apps.Middlewares
{
  public class DateLogMiddleware
  {
    private readonly RequestDelegate _next;

    public DateLogMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
      Debug.WriteLine("Date: " + DateTime.Now.ToLongDateString());
      return _next(httpContext);
    }
  }

  // Extension method used to add the middleware to the HTTP request pipeline.
  public static class DateLogMiddlewareExtensions
  {
    public static IApplicationBuilder UseDateLogMiddleware(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<DateLogMiddleware>();
    }
  }
}