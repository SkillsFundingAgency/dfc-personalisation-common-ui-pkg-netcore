using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.Interfaces
{
    public interface IAdditional
    {
        [HtmlAttributeName("AdditionalClass")]
        string AdditionalClass { get; set; }
    }
}
