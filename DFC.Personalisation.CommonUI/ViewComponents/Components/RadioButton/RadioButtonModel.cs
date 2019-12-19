using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.RadioButton
{
    public class RadioButtonModel : IAdditional, IHtmlBase
    {
        public string AdditionalClass { get; set; }
        public string Id { get; set; }
        public string Value { get; set; }
        public string ChildContent { get; set; }
    }
}
