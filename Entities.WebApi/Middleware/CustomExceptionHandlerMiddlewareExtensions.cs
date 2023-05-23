﻿
namespace Entities.WebApi.Middleware
{
	public static class CustomExceptionHandlerMiddlewareExtensions
	{
		public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
		{
			return app.UseMiddleware<CustomExceptionHandlerMiddleWare>();
		}
	}
}
