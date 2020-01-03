using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Label
{
    public class LabelModel : IAdditional
    {
        public string For { get; set; }
        public string Text { get; set; }
        public string AdditionalClass { get; set; }
    }
}
