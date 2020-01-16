using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents
{
    public interface ILinkAttributes
    {
        string LinkHref { get; set; }
        string LinkText { get; set; }
        string LinkTitle { get; set; }
        int LinkTabIndex { get; set; }
        string Class { get; set; }
        string AdditionalClass { get; set; }
        string Id { get; set; }

    }
    [HtmlTargetElement("govukLink")]
    public class LinkTagHelper : OptionalParamTagHelper, ILinkAttributes
    {
        public string LinkHref { get; set; }
        public string LinkText { get; set; }
        public string LinkTitle { get; set; }
        public int LinkTabIndex { get; set; }
        public string Class { get; set; }
        public string AdditionalClass { get; set; }
        public string Id { get; set; }

        public LinkTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }
    public class Link : BaseViewComponent, ILinkAttributes
    {
        private readonly string viewName;
        private readonly string _svgTag;
        private readonly string _additionalClass;

        public string LinkHref { get; set; }
        public string LinkText { get; set; }
        public string LinkTitle { get; set; }
        public int LinkTabIndex { get; set; }
        public string Class { get; set; }
        public string AdditionalClass { get; set; }
        public string Id { get; set; }

        public Link(string additionalButtonCSS = null, string viewName = "Default.cshtml",
            string svgTag = null)
        {
            this._additionalClass = additionalButtonCSS;
            this.viewName = viewName;
            this._svgTag = svgTag;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new LinkModel()
            {
                LinkText = LinkText,
                AdditionalClass = string.IsNullOrWhiteSpace(this._additionalClass) ? AdditionalClass : this._additionalClass,
                LinkHref = LinkHref,
                LinkTitle = LinkTitle,
                LinkTabIndex = LinkTabIndex,
                Id = Id,
                Class = Class,
                SvgTag = _svgTag

            };
            return View($"/Views/Shared/Components/BaseComponents/Link/{this.viewName}", model);
        }
    }
}
