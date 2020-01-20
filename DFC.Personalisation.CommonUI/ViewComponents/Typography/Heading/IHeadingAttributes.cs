using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Typography.Heading
{
    public interface IHeadingAttributes : IAdditional
    {
        string Text { get; set; }
        string Caption { get; set; }
    }
}
