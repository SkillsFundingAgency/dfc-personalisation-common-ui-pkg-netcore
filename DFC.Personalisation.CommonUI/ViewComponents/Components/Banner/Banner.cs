﻿using System;
using System.Collections.Generic;
using System.Text;
using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.Banner
{
    [HtmlTargetElement("govukPrimaryHeroBanner")]
    public class PrimaryHeroBannerTagHelper : OptionalParamTagHelper, IBanner 
    {
        public string Id { get; set; }
        public string HeaderText { get; set; }
        public string SubheaderText { get; set; }

        public PrimaryHeroBannerTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }
    public class PrimaryHeroBanner : BaseViewComponent
    {
        private readonly string _viewName;
        private readonly BannerModel _model;

        public PrimaryHeroBanner(string viewName = "Default.cshtml")
        {
            _viewName = viewName;
            _model = new BannerModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);

            return View($"/Views/Shared/Components/Banner/{this._viewName}", _model);
        }
    }

}
