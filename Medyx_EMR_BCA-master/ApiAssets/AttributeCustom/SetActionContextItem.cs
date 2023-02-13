using Medyx_EMR_BCA.ApiAssets.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Medyx_EMR_BCA.ApiAssets.AttributeCustom
{
    public class SetActionContextItem : Attribute, IActionFilter
    {
        private ActionType ActionType { get; set; }
        public SetActionContextItem(ActionType actionType)
        {
            ActionType = actionType;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Items["Action"] = ActionType;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
