using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Models.Session;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.AttributeCustom
{
    public class SessionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var result = SessionHelper.GetObjectFromJson<UserSession>(context.HttpContext.Session, "UserProfileSessionData");

            if (result == null)
            {
                throw new HttpStatusException(HttpStatusCode.Unauthorized, "Unauthorized");
            }

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
