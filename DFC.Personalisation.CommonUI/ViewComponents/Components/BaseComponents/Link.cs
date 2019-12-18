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

        public string LinkHref { get; set; }
        public string LinkText { get; set; }
        public string LinkTitle { get; set; }
        public int LinkTabIndex { get; set; }
        public string Class { get; set; }
        public string Id { get; set; }

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
                LinkText = LinkText,
                AdditionalClass = _additionalClass,
                LinkHref = LinkHref,
                LinkTitle = LinkTitle,
                LinkTabIndex = LinkTabIndex,
                Id = Id,
                Class = Class

            };
            return View($"/Views/Shared/Components/BaseComponents/Link/{this.viewName}", model);
        }
    }
}
