using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Error
{
    public class ErrorModel : IAdditional, IHtmlBase
    {
        public string Text { get; set; }
        public string AdditionalClass { get; set; }
        public string Id { get; set; }
    }
}
