using System.Diagnostics;
using SberCrudOps.Application.Services;

namespace SberCrudOps.WebApi.Middleware;

/// <summary>
/// Middleware for Request Timing
/// </summary>
public class ResponseTimeMiddleware {  
   
    private readonly RequestDelegate _next;
    
    public ResponseTimeMiddleware(RequestDelegate next)
    {
        _next = next;
    }  
    public async Task Invoke(HttpContext httpContext, ICompletionTimeService completionTimeService)
    {
        //await _next(httpContext);
        
        var httpMethod = httpContext.Request.Method;
        
        if (httpMethod == "POST")
        {
            httpContext.Response.OnStarting(() =>
            {
                //Получаем значения location из header
                httpContext.Response.Headers.TryGetValue("Location", out var value);

                if (value.Count is 0)
                {
                    return Task.CompletedTask;
                }
                
                //Вырезаем все лишнее из строки, оставляем только id
                var id = value[0]?.Replace("/api/SberOperations/", string.Empty);
            
                //Парсим id в int и передаем в сервис для установки времени завершения
                completionTimeService.SaveCompletionTime(int.Parse(id));
                return Task.CompletedTask;
            });
        }
        
        await _next(httpContext);
    }
}  
