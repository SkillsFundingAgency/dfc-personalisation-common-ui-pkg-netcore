using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Error
{
    public interface IErrorAttributes: IAdditional, IHtmlBase
   {
       public string Text { get; set; }
       public bool Hidden { get; set; }
    }
}
