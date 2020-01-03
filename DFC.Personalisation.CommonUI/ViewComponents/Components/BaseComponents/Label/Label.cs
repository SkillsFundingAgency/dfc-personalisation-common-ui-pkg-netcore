using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Label
{
    [HtmlTargetElement("govukLabel")]
    
    public class LabelTagHelper : OptionalParamTagHelper
    {
        public LabelTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class Label : BaseViewComponent
    {
        private readonly string additionalButtonCSS;
        private readonly string viewName;

        public string Text { get; set; }
        public string For { get; set; }

        public Label(string additionalButtonCSS = null, string viewName = "Default.cshtml")
        {
            this.additionalButtonCSS = additionalButtonCSS;
            this.viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new LabelModel()
            {
                Text = Text,
                For = For,
                AdditionalClass = additionalButtonCSS,
            };
            return View($"/Views/Shared/Components/BaseComponents/Label/{this.viewName}", model);
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
}
