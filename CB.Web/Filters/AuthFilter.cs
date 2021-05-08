using CB.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CB.Web.Filters
{
    public class AuthFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var userType = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserType").Value;
            var intUserType = (UserType)System.Enum.Parse(typeof(UserType), userType);
            if (intUserType == UserType.Supervisor)
            {
                var action = context.RouteData.Values["action"].ToString().ToLower();
                var controller = context.RouteData.Values["controller"].ToString();
                var permissions = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Permissions").Value;
                var permissionsArr = permissions.Split(",");
                Permissions a = (Permissions)System.Enum.Parse(typeof(Permissions), controller);
                List<int> userPermissons = new List<int>();
                foreach (var p in permissionsArr.Where(x=> !string.IsNullOrEmpty(x)))
                    userPermissons.Add(int.Parse(p));
                if (!userPermissons.Contains((int)a))
                {
                    context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Auth" },
                        { "action", "AccessDenied" }
                    });
                }
            }
        }
    }
}
