using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.TagHelpers
{
    /// <summary>
    /// It's not currently possible to have optional parameters of a ViewComponent accessed via a TagHelper (https://github.com/aspnet/AspNetCore/issues/5011)
    /// To achieve optional parameters, make your TagHelper inherit from this class and your ViewComponent inherit from <code>BaseViewComponent</code>
    /// </summary>
    public abstract class OptionalParamTagHelper : TagHelper
    {
        private readonly IViewComponentHelper _viewComponentHelper;

        protected OptionalParamTagHelper(IViewComponentHelper viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var name = GetTagName();
            var options = GetOptions(context);
            await SetHtmlContent(output, name, options);
        }

        public virtual async Task ProcessAsyncWithChildren(TagHelperContext context, TagHelperOutput output, string childContentName)
        {
            var name = GetTagName();
            var options = GetOptions(context);
            var children = await output.GetChildContentAsync();

            options.Add(childContentName, children.GetContent());

            await SetHtmlContent(output, name, options);
        }


        private string GetTagName()
        {
            var taghelpername = this.GetType().Name;
            return taghelpername.Replace("TagHelper", "");

        }

        private Dictionary<string,string> GetOptions(TagHelperContext context)
        {
            var options = new Dictionary<string, string>();

            foreach (var attr in context.AllAttributes)
            {
                options.Add(attr.Name, attr.Value.ToString());
            }

            return options;
        }

        private async Task SetHtmlContent(TagHelperOutput output, string name, Dictionary<string,string> options)
        {
            ((IViewContextAware)_viewComponentHelper).Contextualize(ViewContext);
            var content = await _viewComponentHelper.InvokeAsync(name, options);
            output.TagName = null; // prevents taghelper tags being rendered in the final HTML
            output.Content.SetHtmlContent(content);
        }
    }
}
