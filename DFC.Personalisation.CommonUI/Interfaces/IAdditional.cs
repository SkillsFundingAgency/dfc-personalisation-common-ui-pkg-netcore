using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.Interfaces
{
    public interface IAdditional
    {
        [HtmlAttributeName("AdditionClass")]
        string AdditionalClass { get; set; }
    }
}
