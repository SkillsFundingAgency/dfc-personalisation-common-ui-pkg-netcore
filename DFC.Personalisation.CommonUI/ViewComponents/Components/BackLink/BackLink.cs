using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents;

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


    public class BackLink : Link
    {
        public BackLink():base("govuk-back-link") { }
    }
    
}
