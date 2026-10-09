using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookMark.Server.Middleware
{
    public sealed class ExceptionHandlingMiddleware : IExceptionHandler
    {
        private readonly RequestDelegate next;

        // private readonly ILogger<GlobalExceptionHandler> logger;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            // logger = logger;
        }

        public class InvalidRequestException : Exception { }
        public class ExpectedEntityNotFoundException : Exception { }
        public class RequestedAccessException : Exception { }

        // Existing handler method retained for reuse
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            /// TODO: Add logging

            var problemDetails = new ProblemDetails() { Detail = exception.Message };
            switch (exception)
            {
                case UnauthorizedAccessException:
                    problemDetails.Status = StatusCodes.Status401Unauthorized;
                    problemDetails.Title = "You cannot access this resource. Please contact administration for details.";
                    break;
                case RequestedAccessException:
                    problemDetails.Status = StatusCodes.Status403Forbidden;
                    problemDetails.Title = "Your access to this resource has been requested. An administrator will review shortly.";
                    break;
                case InvalidRequestException:
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "The request is missing required or expected fields.";
                    break;
                case ExpectedEntityNotFoundException:
                    problemDetails.Status = StatusCodes.Status500InternalServerError;
                    problemDetails.Title = "Expected a value to return but returned null.";
                    break;
                default:
                    problemDetails.Status = StatusCodes.Status500InternalServerError;
                    problemDetails.Title = "Unexpected server error";
                    break;
            }

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var handled = await TryHandleAsync(context, ex, CancellationToken.None);
                if (!handled)
                {
                    throw;
                }
            }
        }
    }

}