using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.TextInput
{
    public interface ITextAttributes
    {
        public string Id { get; set; }
        public string HintText { get; set; }
        public string ErrorMessage { get; set; }
        public string ChildContent { get; set; }
        public bool HasError { get; set; }
        public string AdditionalClass { get; set; }
    }
    [HtmlTargetElement("govukTextInput")]
    [RestrictChildren("govukHint", "govukError" )]
    public class TextInputTagHelper : OptionalParamTagHelper, ITextAttributes
    {
        public string Id { get; set; }
        public string HintText { get; set; }
        public string ErrorMessage { get; set; }
        public string ChildContent { get; set; }
        public bool HasError { get; set; }
        public string AdditionalClass { get; set; }

        private readonly IViewComponentHelper _viewComponentHelper;
        public TextInputTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await ProcessAsyncWithChildren(context, output, nameof(TextInputModel.ChildContent));
        }
    }

    public class TextInput : BaseViewComponent, ITextAttributes
    {
        private readonly string viewName;

        public string Id { get; set; }
        public string HintText { get; set; }
        public string ErrorMessage { get; set; }
        public string ChildContent { get; set; }
        public bool HasError { get; set; }
        public string AdditionalClass { get; set; }

        public TextInput(string viewName = "Default.cshtml")
        {
            this.viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new TextInputModel()
            {
                AdditionalClass = AdditionalClass,
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
