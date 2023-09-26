using System.Net;
using System.Text.Json;

namespace API.Middlewares.ExceptionHandler
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger,
            IHostEnvironment env)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception unhandelledEx)
            {
                var errorId = new Random().Next(1_000_000, 9_999_999);
                _logger.LogError(unhandelledEx, $"{errorId}:" + unhandelledEx.Message);

                await Respond(context, unhandelledEx, errorId);
            }
        }

        private async Task Respond(HttpContext context, Exception ex, int errorId)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";


            //creating error response
            bool isDevelopment = _env.IsDevelopment();
            var message = isDevelopment ? ex.Message : $"Error id: {errorId}, please provide this id to" +
                $" the administrator";
            var stackTrace = isDevelopment ? (ex.StackTrace ?? "Stack not available") :
                "Internal Server Error";
            var errorResponse = new ErrorResponse(message, stackTrace);

            //serializing error response
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonResponse = JsonSerializer.Serialize(errorResponse, jsonOptions);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
