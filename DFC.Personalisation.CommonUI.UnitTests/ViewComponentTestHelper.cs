using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Reflection;
using System.Threading.Tasks;
using DFC.Personalisation.CommonUI.TagHelpers;
using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Error;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NSubstitute;

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

        public static async Task CallTagHelper(string tag, IMockViewComponentHelper tagHelper, OptionalParamTagHelper componentTag)
        {

            var ctx = new TagHelperContext($"govuk{tag}", new TagHelperAttributeList
            {
                {nameof(Error.Text),""}
            }, new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));

            var output = new TagHelperOutput($"govuk{tag}",
                new TagHelperAttributeList(), (useCachedResult, htmlEncoder) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetContent(string.Empty);
                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                });
            await componentTag.ProcessAsync(ctx, output);

            await tagHelper.Received(1).InvokeAsync(tag, Arg.Any<Dictionary<string, string>>());
        }
    }
}
