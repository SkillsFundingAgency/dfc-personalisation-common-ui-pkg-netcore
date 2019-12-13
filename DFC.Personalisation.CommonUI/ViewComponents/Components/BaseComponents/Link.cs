using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents
{
    [HtmlTargetElement("govukLink")]
    public class LinkTagHelper : OptionalParamTagHelper
    {
        public LinkTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }
    public class Link : BaseViewComponent
    {
        private readonly string _additionalClass;
        private readonly string viewName;

        public string Href { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string TabIndex { get; set; }

        public Link(string additionalButtonCSS = null, string viewName = "Default.cshtml")
        {
            this._additionalClass = additionalButtonCSS;
            this.viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new LinkModel()
            {
                Text = this.Text,
                AdditionalClass = this._additionalClass,
                Href = this.Href,
                Title = this.Title,
                TabIndex = this.TabIndex

            };
            return View($"/Views/Shared/Components/BaseComponents/Link/{this.viewName}", model);
        }
    }
}
