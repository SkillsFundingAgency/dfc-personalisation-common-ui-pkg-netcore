using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Hint
{
    public interface IHintAttributes
    {
        public string HintText { get; set; }
    }
    [HtmlTargetElement("govukHint", ParentTag = "govukTextInput")]
    public class HintTagHelper : OptionalParamTagHelper, IHintAttributes
    {
        public string HintText { get; set; }

        public HintTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class Hint : BaseViewComponent, IHintAttributes
    {
        private readonly string _additionalCss;
        private readonly string viewName;

        public string HintText { get; set; }

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
                HintText = HintText,
                AdditionalClass = this._additionalCss,
            };
            return View($"/Views/Shared/Components/BaseComponents/Hint/{this.viewName}", model);
        }
    }
}
