using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.TextInput
{
    [HtmlTargetElement("govukTextInput")]
    [RestrictChildren("govukHint", "govukTextInputError")]
    public class TextInputTagHelper : OptionalParamTagHelper, ITextInputAttributes
    {
        public string Id { get; set; }
        public string HintText { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError { get; set; }
        public string AdditionalClass { get; set; }
        public string Value { get; set; }

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

    public class TextInput : BaseViewComponent
    {
        private readonly string viewName;
        private readonly TextInputModel model;

        public TextInput(string viewName = "Default.cshtml")
        {
            this.viewName = viewName;
            model = new TextInputModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            model.SetProps(values);

            return View($"/Views/Shared/Components/TextInput/{this.viewName}", model);
        }

    }
}
