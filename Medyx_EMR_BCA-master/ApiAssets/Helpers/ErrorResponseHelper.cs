using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net;
namespace Medyx_EMR_BCA.ApiAssets.Helpers
{
	static public class ErrorResponseHelper
	{
		public static void Error(IApplicationBuilder errorApp, bool isProduct = false)
		{
			errorApp.Run(async context =>
			{
				if (context.Request.Path.StartsWithSegments("/api"))
				{
					var exception = context.Features
						.Get<IExceptionHandlerPathFeature>()
						.Error;
					var code = HttpStatusCode.InternalServerError; // Internal Server Error by default
					if (exception is HttpStatusException httpException)
					{
						code = httpException.Status;
					}
					var errorResult = new ErrorResponse(exception, code);
					var result = JsonConvert.SerializeObject(errorResult);
					context.Response.ContentType = "application/json";
					context.Response.StatusCode = (int)code;
					await context.Response.WriteAsync(result);
				}
				else
				{
					if (isProduct)
					{
						context.Response.Redirect("/Home/Error");
					}
					else
					{
						var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
						throw exceptionFeature.Error;
					}
                }
			});
		}
	}
}
