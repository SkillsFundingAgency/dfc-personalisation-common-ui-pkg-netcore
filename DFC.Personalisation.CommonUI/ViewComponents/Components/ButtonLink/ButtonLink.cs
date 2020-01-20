using DFC.Personalisation.CommonUI.TagHelpers;
using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Link;
using DFC.Personalisation.CommonUI.ViewComponents.Components.Button;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.ButtonLink
{

    [HtmlTargetElement("govukButtonLink")]
    public class ButtonLinkTagHelper : OptionalParamTagHelper, IButtonAttributes
    {
        public string Text { get; set; }
        public bool Disabled { get; set; }
        public string AdditionalClass { get; set; }

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
    public class StartButtonLinkTagHelper : OptionalParamTagHelper, IButtonAttributes
    {
        public string Text { get; set; }
        public bool Disabled { get; set; }
        public string AdditionalClass { get; set; }

        public StartButtonLinkTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class StartButtonLink : Link
    {
        public StartButtonLink()
            : base("govuk-button govuk-button--start", svgTag:"<svg class=\"govuk-button__start-icon\" " +
                                                              "xmlns=\"http://www.w3.org/2000/svg\" width=\"17.5\" height=\"19\" viewBox=\"0 0 33 40\" " +
                                                              "role=\"presentation\" focusable=\"false\"><path fill=\"" +
                                                              "currentColor\" d=\"M0 0h13l20 20-20 20H0l20-20z\"/></svg>")
        { }
    }

    
}
