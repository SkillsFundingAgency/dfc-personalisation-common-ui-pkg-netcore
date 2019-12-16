using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BackLink
{
    public class BackLinkModel : IAdditional, ILink, IHtmlBase
    {
        public string AdditionalClass { get; set; }
        public string Id { get; set; }
        public string LinkHref { get; set; }
        public string LinkText { get; set; }
        public string LinkTitle { get; set; }
        public int LinkTabIndex { get; set; }
    }
}
