using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Routing;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ReadAndWatchList.Classes
{
    public static class Extensions
    {
        //public static string RenderViewToString(this Controller controller, string viewName, object model)
        //{
        //    var testMap = MapPath(viewName);
        //    var testMap2 = testMap +".cshtml";
        //    var viewResultTest1 = ViewEngines.Engines.FindPartialView(controller.ControllerContext, "~/GradeModals/GradeDetailsModal");
        //    var viewResultTest2 = ViewEngines.Engines.FindPartialView(controller.ControllerContext, "~/GradeDetailsModal");
        //    var viewResultTest3 = ViewEngines.Engines.FindPartialView(controller.ControllerContext, "GradeDetailsModal");
        //    var viewResultTest11 = ViewEngines.Engines.FindView(controller.ControllerContext, "~/GradeModals/GradeDetailsModal", null);
        //    var viewResultTest22 = ViewEngines.Engines.FindView(controller.ControllerContext, "~/GradeDetailsModal", null);
        //    var viewResultTest33 = ViewEngines.Engines.FindView(controller.ControllerContext, "GradeDetailsModal", null);
        //    var viewResultTest44 = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, null);

        //    var test = controller.ControllerContext.RouteData.GetRequiredString("action");
        //    var httpContext = new HttpContextWrapper(HttpContext.Current);
        //    var requestContext = new RequestContext(httpContext, new RouteData());
        //    var completeRoute = requestContext.RouteData.Route;
        //    var justValue = requestContext.RouteData.Values["value"];
        //    using (var writer = new StringWriter())
        //    {
        //        var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
        //        controller.ViewData.Model = model;
        //        var viewCxt = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer);
        //        viewCxt.View.Render(viewCxt, writer);
        //        return writer.ToString();
        //    }
        //}

        //public static string MapPath(string filePath)
        //{
        //    var test = AppDomain.CurrentDomain.BaseDirectory;
        //    var repacedPath = filePath.Replace("~", string.Empty).TrimStart('/');
        //    var httpcontext = HttpContext.Current.Server.MapPath(filePath);
        //    return HttpContext.Current != null ? HttpContext.Current.Server.MapPath(filePath) : string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, filePath.Replace("~", string.Empty).TrimStart('/'));
        //}

        public static string RenderViewToString(this Controller controller, string viewPath, object model = null, bool partial = false)
        {
            //var basePath = "~/Views/Grades/GradeModals/GradeDetailsModal.cshtml";
            var basePath = "~/Views/" + controller.ControllerContext.RouteData.GetRequiredString("controller") + "/" + viewPath + ".cshtml";
            ControllerContext context = controller.ControllerContext;
            // test = ViewEngines.Engines.FindView(controller.ControllerContext, "~/Views/Grades/GradeModals/GradeDetailsModal.cshtml", null);
            // first find the ViewEngine for this view
            ViewEngineResult viewEngineResult = null;
            if (partial)
                viewEngineResult = ViewEngines.Engines.FindPartialView(context, basePath);
            else
                viewEngineResult = ViewEngines.Engines.FindView(context, basePath, null);

            if (viewEngineResult == null)
                throw new FileNotFoundException("View cannot be found.");

            // get the view and attach the model to view data
            var view = viewEngineResult.View;
            context.Controller.ViewData.Model = model;

            string result = null;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(context, view,
                                            context.Controller.ViewData,
                                            context.Controller.TempData,
                                            sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }

        public static string DisplayNameForPropertyInClass(this object inClass,string input)
        {
            MemberInfo property = inClass.GetType().GetProperty(input);
            var dd = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            if (dd != null)
            {
                var name = dd.Name;
                return name;
            }
            else
                return null;
        }

        //public static List<string> DisplayNameForAllPropertiesInClass(this object inClass)
        //{
        //    var properties = inClass.GetType().GetProperties();
        //    var returnDisplaynames = new List<string>();
        //    foreach(var prop in properties)
        //    {
        //        var tempString = inClass.DisplayNameForPropertyInClass(prop.Name);
        //        if (tempString != null)
        //            returnDisplaynames.Add(tempString);
        //    }

        //    return returnDisplaynames;
        //}

        public static Dictionary<string,string> DisplayNameForAllPropertiesInClass<T>()
        {
            return TypeDescriptor.GetProperties(typeof(T))
                          .Cast<PropertyDescriptor>()
                          .ToDictionary(p => p.Name, p => p.DisplayName);
        }

        public static Dictionary<string, string> DisplayNameForAllPropertiesInClass(this Type inType)
        {
            PropertyInfo[] listPI = inType.GetProperties();
            Dictionary<string, string> dictDisplayNames = new Dictionary<string, string>();
            string displayName = string.Empty;

            foreach (PropertyInfo pi in listPI)
            {
                //DisplayNameAttribute dp = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
                var dp = pi.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                if (dp != null)
                {
                    displayName = dp.Name;
                    dictDisplayNames.Add(pi.Name, displayName);
                }
                else
                {
                    dictDisplayNames.Add(pi.Name, pi.Name);
                }
            }

            return dictDisplayNames;
        }
    }
}