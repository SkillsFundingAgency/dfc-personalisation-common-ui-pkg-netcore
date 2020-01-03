using System;
using System.Collections.Generic;
using System.Text;
using DFC.Personalisation.CommonUI.TagHelpers;
using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.ButtonLink
{

    [HtmlTargetElement("govukButtonLink")]
    public class ButtonLinkTagHelper : OptionalParamTagHelper
    {
        public ButtonLinkTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class ButtonLink : Link
    {
        public ButtonLink()
            : base("govuk-button")
        { }
    }

    [HtmlTargetElement("govukStartButtonLink")]
    public class StartButtonLinkTagHelper : OptionalParamTagHelper
    {
        public StartButtonLinkTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class StartButtonLink : Link
    {
        public StartButtonLink()
            : base("govuk-button govuk-button--start")
        { }
    }

    
}
