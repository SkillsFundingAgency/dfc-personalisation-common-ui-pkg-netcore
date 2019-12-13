using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents
{
    public class LinkModel : ILink, IAdditional, IHtmlBase
    {
        public string Href { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string TabIndex { get; set; }
        public string Class { get; set; }
        public string AdditionalClass { get; set; }
        public string Id { get; set; }
    }
}
