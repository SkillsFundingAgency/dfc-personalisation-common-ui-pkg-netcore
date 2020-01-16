using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.RadioButton
{
    public interface IRadioButtonAttributes
    {
        string Id { get; set; }
        string Value { get; set; }
        string ChildContent { get; set; }
    }
    [HtmlTargetElement("govukRadioButton")]
    [RestrictChildren("govukRadioLabel")]
    public class RadioButtonTagHelper : OptionalParamTagHelper, IRadioButtonAttributes
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string ChildContent { get; set; }

        private readonly IViewComponentHelper _viewComponentHelper;
        public RadioButtonTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await ProcessAsyncWithChildren(context, output, nameof(RadioButtonModel.ChildContent));
        }

    }

    public class RadioButton : BaseViewComponent, IRadioButtonAttributes
    {
        private readonly string additionalButtonCSS;
        private readonly string viewName;

        public string Id { get; set; }
        public string Value { get; set; }
        public string ChildContent { get; set; }

        public RadioButton(string additionalButtonCSS = null, string viewName = "Default.cshtml")
        {
            this.additionalButtonCSS = additionalButtonCSS;
            this.viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new RadioButtonModel()
            {
                AdditionalClass = additionalButtonCSS,
                Id = Id,
                ChildContent = ChildContent,
                Value = Value

            };
            return View($"/Views/Shared/Components/RadioButton/{this.viewName}", model);
        }
    }
}
