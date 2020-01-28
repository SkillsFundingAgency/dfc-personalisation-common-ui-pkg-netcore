using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.RadioButton
{
    [HtmlTargetElement("govukRadioButton")]
    [RestrictChildren("govukRadioLabel", "govukRadioHint")]
    public class RadioButtonTagHelper : OptionalParamTagHelper, IRadioButtonAttributes
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }

        public string AdditionalClass { get; set; }

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

    public class RadioButton : BaseViewComponent
    {
        private readonly string additionalButtonCSS;
        private readonly string viewName;
        private readonly RadioButtonModel _model;

        public RadioButton(string additionalButtonCSS = null, string viewName = "Default.cshtml")
        {
            this.additionalButtonCSS = additionalButtonCSS;
            this.viewName = viewName;
            _model = new RadioButtonModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);
            _model.AdditionalClass = AutoPropsHelper.CombineClassProps(new List<string>
            {
                {_model.AdditionalClass },
                {additionalButtonCSS }
            });

            return View($"/Views/Shared/Components/RadioButton/{this.viewName}", _model);
        }
    }
}
