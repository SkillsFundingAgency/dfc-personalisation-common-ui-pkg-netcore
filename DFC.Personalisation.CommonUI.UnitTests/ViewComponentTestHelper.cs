using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Reflection;

namespace DFC.Personalisation.CommonUI.UnitTests
{
    public class ViewComponentTestHelper
    {
        public static string GetPropertyValue(object model, string property)
        {
           var prop = model.GetType().GetProperty(property,
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

           return prop.GetValue(model).ToString();

        }

        public static ViewComponentContext GeViewComponentContext()
        {
            var httpContext = new DefaultHttpContext();
            var viewContext = new ViewContext();
            viewContext.HttpContext = httpContext;
            var viewComponentContext = new ViewComponentContext();
            viewComponentContext.ViewContext = viewContext;

            return viewComponentContext;
        }
    }
}
