using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.RadioButton
{
    public interface IRadioButtonAttributes : IAdditional, IHtmlBase
    {
        string Value { get; set; }
    }
}
