using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.Banner
{
    public interface IBanner
    {
        string Id { get; set; }

        string HeaderText { get; set; }
        string SubheaderText { get; set; }
    }
}
