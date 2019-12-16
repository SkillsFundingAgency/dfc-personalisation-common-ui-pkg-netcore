﻿using System.Collections.Generic;
using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.Button
{
    [HtmlTargetElement("govukButton")]
    public class ButtonTagHelper : OptionalParamTagHelper
    {
        public ButtonTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }


    public class Button : BaseViewComponent
    {
        private readonly string additionalButtonCSS;
        private readonly string viewName;

        public string Text { get; set; }
        public bool Disabled { get; set; }

        public Button(string additionalButtonCSS = null, string viewName = "Default.cshtml")
        {
            this.additionalButtonCSS = additionalButtonCSS;
            this.viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new ButtonModel()
            {
                Text = this.Text,
                Disabled = this.Disabled,
                AdditionalClass = this.additionalButtonCSS,
            };
            return View($"/Views/Shared/Components/Button/{this.viewName}", model);
        }
    }

    [HtmlTargetElement("govukStartButton")]
    public class StartButtonTagHelper : OptionalParamTagHelper
    {
        public StartButtonTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class StartButton : Button
    {
        public StartButton()
         : base("govuk-button--start", "StartButton.cshtml")
        { }
    }

    [HtmlTargetElement("govukSecondaryButton")]
    public class SecondaryButtonTagHelper : OptionalParamTagHelper
    {
        public SecondaryButtonTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class SecondaryButton : Button
    {
        public SecondaryButton()
         : base("govuk-button--secondary")
        { }
    }

    [HtmlTargetElement("govukWarningButton")]
    public class WarningButtonTagHelper : OptionalParamTagHelper
    {
        public WarningButtonTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class WarningButton : Button
    {
        public WarningButton()
         : base("govuk-button--warning")
        { }
    }
}