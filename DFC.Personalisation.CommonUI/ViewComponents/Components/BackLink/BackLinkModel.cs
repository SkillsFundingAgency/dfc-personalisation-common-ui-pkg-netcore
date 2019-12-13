using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BackLink
{
    public class BackLinkModel : IAdditional, ILink, IHtmlBase
    {
        public string Href { get; set; }
        public string LinkText { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string AdditionalClass { get; set; }
        public string TabIndex { get; set; }
        public string Class { get; set; }
        public string LinkTitle { get; set; }
        public string Id { get; set; }
    }
}
