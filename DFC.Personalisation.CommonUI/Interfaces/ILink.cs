using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.Interfaces
{
    public interface ILink
    {
        [HtmlAttributeName("LinkHref")]
        string LinkHref { get; set; }
        [HtmlAttributeName("LinkText")]
        string LinkText { get; set; }
        [HtmlAttributeName("LinkTitle")]
        string LinkTitle { get; set; }
        [HtmlAttributeName("LinkTabIndex")]
        int LinkTabIndex { get; set; }
    }
}
