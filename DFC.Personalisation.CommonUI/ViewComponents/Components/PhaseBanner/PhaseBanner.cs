using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.PhaseBanner
{
    [HtmlTargetElement("govukPhaseBanner")]
    public class PhaseBannerTagHelper : OptionalParamTagHelper, IPhaseBanner
    {
        public string Id { get; set; }
        public IPhaseBanner.ProjectPhase Phase { get; set; }

        public PhaseBannerTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class PhaseBanner : BaseViewComponent
    {
        private readonly string _viewName;
        private readonly PhaseBannerModel _model;

        public PhaseBanner(string viewName = "Default.cshtml")
        {
            _viewName = viewName;
            _model = new PhaseBannerModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);

            return View($"/Views/Shared/Components/PhaseBanner/{this._viewName}", _model);
        }
    }
}
