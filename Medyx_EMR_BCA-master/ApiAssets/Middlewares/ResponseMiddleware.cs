using Medyx_EMR_BCA.ApiAssets.Constants;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.ApiAssets.Middlewares
{
	public class ResponseMiddleware
	{
		public class ResponseClass
		{
			//public int count { get; set; }

			//public DateTime timestamp { get; set; }

			public int statusCode { get; set; }
			public string message { get; set; }

			public object data { get; set; }
		}
		private readonly RequestDelegate _next;

		public ResponseMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			if (IsWeb(context) || IsDownloadFile(context))
				await this._next(context);
			else
			{
				var existingBody = context.Response.Body;
      
				using (var newBody = new MemoryStream())
				{
					context.Response.Body = newBody;
					{
						await _next(context);
						var actionType = context.Items["Action"];
						var newResponse = await FormatResponse(context.Response, actionType);
						context.Response.Body = new MemoryStream();
						newBody.Seek(0, SeekOrigin.Begin);
						context.Response.Body = existingBody;
						var newContent = JsonConvert.DeserializeObject(new StreamReader(newBody).ReadToEnd());
						context.Response.ContentType = "application/json";
						CacheResponseHeaderHelper.AddCache(context);
						await context.Response.WriteAsync(newResponse);
					}
				}
			}
		}

		private bool IsDownloadFile(HttpContext context)
        {
			var path = context.Request.Path.ToString();
			return path.Contains("print-ba-file") || path.Contains("download-ba-file"); 
        }
		private bool IsWeb(HttpContext context)
		{
			return !context.Request.Path.StartsWithSegments("/api");
		}
		private bool IsError(HttpContext context)
		{
			return context.Request.Path.StartsWithSegments("/error");
		}
		private bool IsSwagger(HttpContext context)
		{
			return context.Request.Path.StartsWithSegments("/swagger");
		}
		private async Task<string> FormatResponse(HttpResponse response, object actionType)
		{
			//We need to read the response stream from the beginning...and copy it into a string...I'D LIKE TO SEE A BETTER WAY TO DO THIS
			//
			response.Body.Seek(0, SeekOrigin.Begin);
			var content = await new StreamReader(response.Body).ReadToEndAsync();


			var Response = new ResponseClass();

			if (!IsResponseValid(response) || (actionType != null && actionType.Equals(ActionType.PagedList)))
			{
				return $"{content}";
			}
			Response.statusCode = response.StatusCode;
			Response.message = handlerMessage(actionType);

			try
			{
				Response.data = JContainer.Parse(content);
			}
			catch
			{
				Response.data = content;
			}
			var json = JsonConvert.SerializeObject(Response);

			//Response.count = response.ToString().Length;


			//We need to reset the reader for the response so that the client an read it
			response.Body.Seek(0, SeekOrigin.Begin);
			return $"{json}";
		}

		private string handlerMessage(object actionType)
		{
			switch (actionType)
			{
				case ActionType.Create:
					return MessageTypeConstant.createSuccess;
				case ActionType.List:
					return MessageTypeConstant.getListSuccess;
				case ActionType.Update:
					return MessageTypeConstant.updateSuccess;
				case ActionType.Delete:
					return MessageTypeConstant.deleteSuccess;
				default:
					return "success";
			}
		}
		private bool IsResponseValid(HttpResponse response)
		{
			if ((response != null)
				&& (response.StatusCode == 200
				|| response.StatusCode == 201
				|| response.StatusCode == 202
				))
			{
				return true;
			}
			return false;
		}
		private bool IsFile(HttpResponse response)
		{
			return response.ContentType == System.Net.Mime.MediaTypeNames.Application.Octet;
		}
	}
}
