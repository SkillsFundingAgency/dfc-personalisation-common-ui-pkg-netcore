using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.CheckBox
{
    public interface ICheckboxAttributes : IAdditional, IHtmlBase
    {
        string Label { get; set; }
        bool Checked { get; set; }
        string Name { get; set; }
        string Value { get; set; }
    }
}
