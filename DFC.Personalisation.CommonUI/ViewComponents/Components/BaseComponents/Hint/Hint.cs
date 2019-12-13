using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Hint
{
    [HtmlTargetElement("govukHint", ParentTag = "govukTextInput")]
    public class HintTagHelper : OptionalParamTagHelper
    {
        public HintTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class Hint : BaseViewComponent
    {
        private readonly string _additionalCss;
        private readonly string viewName;

        public string Text { get; set; }

        public Hint(string additionalCss = null, string viewName = "Default.cshtml")
        {
            this._additionalCss = additionalCss;
            this.viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new HintModel()
            {
                HintText = Text,
                AdditionalClass = this._additionalCss,
            };
            return View($"/Views/Shared/Components/BaseComponents/Hint/{this.viewName}", model);
        }
    }
}
