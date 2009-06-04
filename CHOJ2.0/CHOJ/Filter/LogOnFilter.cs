using System;
using System.Web.Mvc;

namespace CHOJ
{
    public class LoginedFilter : ActionFilterAttribute
    {
        public string Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!Role.IsNullOrEmpty())
            {
                if(HalfoxUser.Role!=Role)
                    filterContext.HttpContext.Response.Redirect("/");
            }
            if (!HalfoxUser.HasLogOn)
            {
                filterContext.HttpContext.Response.Redirect("/");
            }
        }
    }
}