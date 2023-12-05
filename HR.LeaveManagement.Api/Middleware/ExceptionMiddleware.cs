using HR.LeaveManagement.Api.Models;
using HR.LeaveManagement.Application.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using SendGrid.Helpers.Errors.Model;
using System.Net;

namespace HR.LeaveManagement.Api.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
		{
			HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
			CustomProblemDetails problem = new();

			switch (ex)
			{
				case Application.Exceptions.BadRequestException badRequestException:
					statusCode = HttpStatusCode.BadRequest;
					problem = new CustomProblemDetails
					{
						Title = badRequestException.Message,
						Status = (int)statusCode,
						Detail = badRequestException.InnerException?.Message,
						Type = nameof(Application.Exceptions.BadRequestException),
						Errors = badRequestException.ValidationErrors
					};

					break;
				case Application.Exceptions.NotFoundException notFound:
					statusCode = HttpStatusCode.NotFound;
					problem = new CustomProblemDetails
					{
						Title = notFound.Message,
						Status = (int)statusCode,
						Detail = notFound.InnerException?.Message,
						Type = nameof(Application.Exceptions.NotFoundException),
					};
					break;
				default:
					problem = new CustomProblemDetails
					{
						Title = ex.Message,
						Status = (int)statusCode,
						Detail = ex.StackTrace,
						Type = nameof(HttpStatusCode.InternalServerError),
					};
					break;
			}

			httpContext.Response.StatusCode = (int)statusCode;
			await httpContext.Response.WriteAsJsonAsync(problem);
		}
	}
}
