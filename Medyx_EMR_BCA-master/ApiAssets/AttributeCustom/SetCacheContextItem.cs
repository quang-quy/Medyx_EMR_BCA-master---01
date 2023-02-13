using Medyx_EMR_BCA.ApiAssets.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Medyx_EMR_BCA.ApiAssets.AttributeCustom
{
    public class SetCacheContextItem : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Items["Cache-Data-List"] = true;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
