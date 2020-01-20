namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Link
{
    public class LinkModel : ViewModelBase, ILinkAttributes
    {
        public string LinkHref { get; set; }
        public string LinkText { get; set; }
        public string LinkTitle { get; set; }
        public int LinkTabIndex { get; set; }
        public string Class { get; set; }
        public string AdditionalClass { get; set; }
        public string Id { get; set; }
        public string SvgTag { get; set; }
    }
}
