using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Label
{
    public interface ILabelAttributes : IAdditional
    {
        public string For { get; set; }
        public string Text { get; set; }
    }
}
