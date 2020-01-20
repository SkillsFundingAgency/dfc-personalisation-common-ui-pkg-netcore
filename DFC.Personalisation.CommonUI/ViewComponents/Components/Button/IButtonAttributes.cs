using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.Button
{
    public interface IButtonAttributes : IAdditional, IHtmlBase
    {
        string Id { get; set; }
        string Text { get; set; }
        bool Disabled { get; set; }
    }
}
