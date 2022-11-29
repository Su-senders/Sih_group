using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Web.Helper
{
    public static class AdminLteNavigationIndicator
    {
        public static string MakeActiveClass(this IUrlHelper urlHelper, string area, string controller, string action)
        {
            //try
            //{
            //    string result = "active";
            //    try
            //    {
            //        string areaName = urlHelper.ActionContext.RouteData.Values["area"].ToString();
            //    }
            //    catch (Exception)
            //    {

            //        return null;
            //    }
            //    //string areaName = urlHelper.ActionContext.RouteData.Values["area"].ToString();
            //    string controllerName = urlHelper.ActionContext.RouteData.Values["controller"].ToString();
            //    string methodName = urlHelper.ActionContext.RouteData.Values["action"].ToString();
            //    if (string.IsNullOrEmpty(controllerName)) return null;
            //    if (controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
            //    {
            //        if (methodName.Equals(action, StringComparison.OrdinalIgnoreCase))
            //        {
            //            return result;
            //        }
            //    }
            //    return null;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
            return null;
        }
    }
}
