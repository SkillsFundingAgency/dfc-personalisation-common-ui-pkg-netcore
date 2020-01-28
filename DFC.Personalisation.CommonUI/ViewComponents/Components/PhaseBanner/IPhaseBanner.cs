namespace DFC.Personalisation.CommonUI.ViewComponents.Components.PhaseBanner
{
    public interface IPhaseBanner
    {
        public enum ProjectPhase
        {
            Alpha,
            Beta
        }

        string Id { get; set; }

        public ProjectPhase Phase { get; set; }
    }
}
