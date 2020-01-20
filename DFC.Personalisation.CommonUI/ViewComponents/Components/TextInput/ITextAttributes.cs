using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.TextInput
{
    public interface ITextInputAttributes : IAdditional, IHtmlBase
    {
        public string HintText { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError { get; set; }
    }
}
