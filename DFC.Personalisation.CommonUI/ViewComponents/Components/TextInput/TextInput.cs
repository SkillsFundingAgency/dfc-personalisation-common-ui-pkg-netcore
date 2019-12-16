using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.TextInput
{
    [HtmlTargetElement("govukTextInput")]
    [RestrictChildren("govukHint", "govukError" )]
    public class TextInputTagHelper : OptionalParamTagHelper
    {
        private readonly IViewComponentHelper _viewComponentHelper;
        public TextInputTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            ((IViewContextAware)_viewComponentHelper).Contextualize(ViewContext);

            var taghelpername = this.GetType().Name;
            var name = taghelpername.Replace("TagHelper", "");
            var options = new Dictionary<string, string>();

            foreach (var attr in context.AllAttributes)
            {
                options.Add(attr.Name, attr.Value.ToString());
            }

            if (string.IsNullOrWhiteSpace(name)) { output.SuppressOutput(); return; }

            var children = await output.GetChildContentAsync();

            options.Add(nameof(TextInputModel.ChildContent),children.GetContent());

            var content = await _viewComponentHelper.InvokeAsync(name, options);
            output.TagName = null; // prevents taghelper tags being rendered in the final HTML
            output.Content.SetHtmlContent(content);
        }
    }

    public class TextInput : BaseViewComponent
    {
        private readonly string _additionalCss;
        private readonly string viewName;

        public string Id { get; set; }
        public string HintText { get; set; }
        public string ErrorMessage { get; set; }
        public string ChildContent { get; set; }
        public bool HasError { get; set; }

        public TextInput(string additionalCss = null, string viewName = "Default.cshtml")
        {
            this._additionalCss = additionalCss;
            this.viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new TextInputModel()
            {
                AdditionalClass = _additionalCss,
                ChildContent = ChildContent,
                HasError = HasError,
                Id = Id,
                HintText = HintText,
                ErrorMessage = ErrorMessage
            };
            return View($"/Views/Shared/Components/TextInput/{this.viewName}", model);
        }

    }


}
