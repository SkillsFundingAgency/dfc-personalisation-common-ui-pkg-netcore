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

        public OptionalParamTagHelper(IViewComponentHelper viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            ((IViewContextAware)_viewComponentHelper).Contextualize(ViewContext);

            var taghelpername = this.GetType().Name;
            var name = taghelpername.Replace("TagHelper", "");
            var options = new Dictionary<string,string>();

            foreach (var attr in context.AllAttributes)
            {
                options.Add(attr.Name, attr.Value.ToString());
            }

            if (string.IsNullOrWhiteSpace(name)) { output.SuppressOutput(); return; }

            var content = await _viewComponentHelper.InvokeAsync(name, options);
            output.TagName = null; // prevents taghelper tags being rendered in the final HTML
            output.Content.SetHtmlContent(content);
        }
    }
}
