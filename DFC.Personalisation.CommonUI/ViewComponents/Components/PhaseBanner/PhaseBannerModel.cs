namespace DFC.Personalisation.CommonUI.ViewComponents.Components.PhaseBanner
{
    public class PhaseBannerModel : ViewModelBase, IPhaseBanner
    {
        public string Id { get; set; }
        public IPhaseBanner.ProjectPhase Phase { get; set; }

        public string FeedbackHref { get; set; }

        public PhaseBannerModel()
        {
            Id = null;
            Phase = IPhaseBanner.ProjectPhase.Alpha;
            FeedbackHref = "#";
        }
    }
}
