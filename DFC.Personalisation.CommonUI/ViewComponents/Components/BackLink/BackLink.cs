using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BackLink
{
    [HtmlTargetElement("govukBackLink")]
    public class BackLinkTagHelper : OptionalParamTagHelper
    {
        public BackLinkTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }


    public class BackLink :BaseViewComponent
    {

        private readonly string additionalButtonCSS;
        private readonly string viewName;

        public string Text { get; set; }
        public bool Disabled { get; set; }

        public BackLink(string additionalButtonCSS = null, string viewName = "Default.cshtml")
        {
            this.additionalButtonCSS = additionalButtonCSS;
            this.viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new BackLinkModel()
            {
                LinkText = this.Text,
                AdditionalClass = this.additionalButtonCSS,
                Href = "",
                LinkTitle = ""
            };
            return View($"/Views/Shared/Components/BackLink/{this.viewName}", model);
        }
    }
}
