namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Error
{
    public class ErrorModel : ViewModelBase, IErrorAttributes
    {
        public string AdditionalClass { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
