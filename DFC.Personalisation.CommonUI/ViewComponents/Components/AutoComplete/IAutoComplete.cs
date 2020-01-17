namespace DFC.Personalisation.CommonUI.ViewComponents.Components.AutoComplete
{
    public interface IAutoComplete
    {
        string Source { get; set; }
        string Element { get; set; }
        string Id { get; set; }
        bool AutoSelect { get; set; }
        bool ConfirmOnBlur { get; set; }
        string CssNameSpace { get; set; }
        string DefaultValue { get; set; }
        string DisplayMenu { get; set; }
        int MinLength { get; set; }
        string Name { get; set; }
        string OnConfirm { get; set; }
        bool Required { get; set; }
        bool ShowAllValues { get; set; }
        bool ShowNoOptionsFound { get; set; }
        string LabelText { get; set; }
        string FunctionName { get; set; }
    }
}
