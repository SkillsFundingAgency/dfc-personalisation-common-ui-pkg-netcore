using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Label
{
    
    [HtmlTargetElement("govukLabel")]
    public class LabelTagHelper : OptionalParamTagHelper, ILabelAttributes
    {
        public string Text { get; set; }
        public string For { get; set; }

        public string AdditionalClass { get; set; }

        public LabelTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class Label : BaseViewComponent
    {
        private readonly string additionalButtonCSS;
        private readonly string viewName;
        private readonly LabelModel _model;


        public Label(string additionalButtonCSS = null, string viewName = "Default.cshtml")
        {
            this.additionalButtonCSS = additionalButtonCSS;
            this.viewName = viewName;
            _model = new LabelModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);

            _model.AdditionalClass = AutoPropsHelper.CombineClassProps(new List<string>
            {
                _model.AdditionalClass,
                additionalButtonCSS
            });

            return View($"/Views/Shared/Components/BaseComponents/Label/{this.viewName}", _model);
        }
    }
    [HtmlTargetElement("govukRadioLabel", ParentTag = "govukRadioButton")]

    public class RadioLabelTagHelper : OptionalParamTagHelper
    {
        public RadioLabelTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class RadioLabel : Label
    {
        public RadioLabel() : base("govuk-radios__label") { }
    }




    [HtmlTargetElement("govukAutoCompleteLabel", ParentTag = "govukAutoComplete")]

    public class AutoCompleteLabelTagHelper : OptionalParamTagHelper
    {
        public AutoCompleteLabelTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class AutoCompleteLabel : Label
    {
        public AutoCompleteLabel() : base("govuk-heading-m") { }
    }
}
