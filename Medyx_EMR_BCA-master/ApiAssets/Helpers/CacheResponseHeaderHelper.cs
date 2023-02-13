
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Medyx_EMR_BCA.ApiAssets.Helpers
{
	public static class CacheResponseHeaderHelper
	{
		private static readonly int timeCache = 2;
		private static readonly int timeMinuteCache = 60;
		public static async Task AddCache(HttpContext context, Func<Task> next)
		{
			if (context.Items["Cache-Data-List"] != null && (bool)context.Items["Cache-Data-List"] == true)
			{
				context.Response.GetTypedHeaders().CacheControl =
						new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
						{
							Public = true,
							MaxAge = TimeSpan.FromSeconds(60),
						};
			}
			await next();
		}
		public static void AddCache(HttpContext context)
		{
			if (context.Items["Cache-Data-List"] != null && (bool)context.Items["Cache-Data-List"] == true)
			{
				context.Response.GetTypedHeaders().CacheControl =
						new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
						{
							Public = true,
							MaxAge = TimeSpan.FromMinutes(timeMinuteCache)
							// MaxAge = TimeSpan.FromDays(timeCache),
						};
			}
		}
	}

}
