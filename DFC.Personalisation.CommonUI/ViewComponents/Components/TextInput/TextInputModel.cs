namespace DFC.Personalisation.CommonUI.ViewComponents.Components.TextInput
{
    public class TextInputModel : ViewModelBase, ITextInputAttributes
    {
        public string AdditionalClass { get; set; }
        public string Id { get; set; }
        public string HintText { get; set; }
        public string ErrorMessage { get; set; }
        public string ChildContent { get; set; }
        public bool HasError { get; set; }
        public string Value { get; set; }
    }
}
