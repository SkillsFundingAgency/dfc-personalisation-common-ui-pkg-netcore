using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents
{
    
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
    public class Link : BaseViewComponent
    {
        private readonly string viewName;
        private readonly string _svgTag;
        private readonly string _additionalClass;
        private readonly LinkModel _model;
        
        public Link(string additionalButtonCSS = null, string viewName = "Default.cshtml",
            string svgTag = null, string text = "")
        {
            this._additionalClass = additionalButtonCSS;
            this.viewName = viewName;
            this._svgTag = svgTag;
            _model = new LinkModel{LinkText = text};
        }


        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);

            var model = new LinkModel()
            {
                LinkText = _model.LinkText,
                AdditionalClass = string.IsNullOrWhiteSpace(this._additionalClass) ? _model.AdditionalClass : this._additionalClass,
                LinkHref = _model.LinkHref,
                LinkTitle = _model.LinkTitle,
                LinkTabIndex = _model.LinkTabIndex,
                Id = _model.Id,
                Class = _model.Class,
                SvgTag = _svgTag

            };
            return View($"/Views/Shared/Components/BaseComponents/Link/{this.viewName}", model);
        }
    }
}
