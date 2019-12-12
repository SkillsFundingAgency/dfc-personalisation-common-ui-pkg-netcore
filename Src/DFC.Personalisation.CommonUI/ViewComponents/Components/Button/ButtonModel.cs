using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.Button
{
    public class ButtonModel: IAdditional
    {
        public string Text { get; set; }

        public bool Disabled { get; set; }

        public string AdditionalClass { get; set; }
    }
}
