using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.Banner
{
    public interface IBanner
    {
        string Id { get; set; }
        [HtmlAttributeName("headerText")]
        string HeaderText { get; set; }
        [HtmlAttributeName("subheaderText")]
        string SubheaderText { get; set; }
    }
}
