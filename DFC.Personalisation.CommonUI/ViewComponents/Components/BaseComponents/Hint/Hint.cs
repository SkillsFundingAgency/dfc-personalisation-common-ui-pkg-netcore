using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Hint
{
    [HtmlTargetElement("govukHint", ParentTag = "govukTextInput")]
    public class HintTagHelper : OptionalParamTagHelper, IHintAttributes
    {
        public string HintText { get; set; }

        public HintTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }

        public string AdditionalClass { get; set; }
        public string Id { get; set; }
    }

    public class Hint : BaseViewComponent
    {
        private readonly string _additionalCss;
        private readonly string viewName;
        private readonly HintModel _model;
        
        public Hint(string additionalCss = null, string viewName = "Default.cshtml")
        {
            this._additionalCss = additionalCss;
            this.viewName = viewName;
            _model = new HintModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);
            _model.AdditionalClass = AutoPropsHelper.CombineClassProps(new List<string>
            {
                _model.AdditionalClass,
                _additionalCss
            });

            return View($"/Views/Shared/Components/BaseComponents/Hint/{this.viewName}", _model);
        }
    }

    [HtmlTargetElement("govukRadioHint", ParentTag = "govukRadioButton")]
    public class RadioHintTagHelper : OptionalParamTagHelper, IHintAttributes
    {
        public string HintText { get; set; }

        public RadioHintTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }

        public string AdditionalClass { get; set; }
        public string Id { get; set; }
    }
    public class RadioHint : Hint
    {
        public RadioHint() : base("govuk-radios__hint")
        {
        }

    }
    
}
