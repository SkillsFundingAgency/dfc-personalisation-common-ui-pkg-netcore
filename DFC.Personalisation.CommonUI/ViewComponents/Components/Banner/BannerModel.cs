namespace DFC.Personalisation.CommonUI.ViewComponents.Components.Banner
{
    public class BannerModel : ViewModelBase, IBanner
    {
        public string Id { get; set; }
        public string HeaderText { get; set; }
        public string SubheaderText { get; set; }
    }
}
