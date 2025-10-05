
using System.Net;
using System.Text.Json;

namespace Inventory_Management_System_API.GlobalExceptionHandler
{
    public class CustomExceptionHandler : IMiddleware
    {
        private HttpContext _context;
        private RequestDelegate next;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "An unexpected error occurred.";

            switch (ex)
            {
                case AutoMapper.AutoMapperMappingException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "Invalid data mapping. Please check the request payload.";
                    break;

                case ArgumentException argEx:
                    statusCode = HttpStatusCode.BadRequest;
                    message = argEx.Message;
                    break;

                case KeyNotFoundException notFoundEx:
                    statusCode = HttpStatusCode.NotFound;
                    message = notFoundEx.Message;
                    break;
            }

            var errorResponse = new
            {
                StatusCode = (int)statusCode,
                Message = message,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
        }
    }
}
