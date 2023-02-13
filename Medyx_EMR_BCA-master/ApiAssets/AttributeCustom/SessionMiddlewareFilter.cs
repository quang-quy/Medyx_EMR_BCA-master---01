using System.Linq;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.AttributeCustom
{
	public class SessionMiddlewareFilter : Attribute, IActionFilter
	{
		private string[] Actions { get; set; }
		public SessionMiddlewareFilter(params string[] actions)
		{
			Actions = actions;
		}
		public void OnActionExecuting(ActionExecutingContext context)
		{
			var result = SessionHelper.GetObjectFromJson<UserSession>(context.HttpContext.Session, "UserProfileSessionData");

			if (result == null)
			{
				throw new HttpStatusException(HttpStatusCode.Unauthorized, "Unauthorized");
			}
			if (Actions.Length > 0)
			{
                var find = result.ListRoleSession.ToList().Find(x => Actions.Any(a => a == x.ActionDetailsName || $"/{a}" == x.ActionDetailsName));
				if (find == null)
				{
					throw new HttpStatusException(HttpStatusCode.Forbidden, "Bạn không có quyền sử dụng chức năng này");
				}
			}
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{

		}
	}
}
