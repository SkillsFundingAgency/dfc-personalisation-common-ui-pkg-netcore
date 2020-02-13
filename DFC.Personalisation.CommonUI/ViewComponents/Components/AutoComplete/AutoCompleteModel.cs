namespace DFC.Personalisation.CommonUI.ViewComponents.Components.AutoComplete
{
    public class AutoCompleteModel : ViewModelBase, IAutoComplete
    {
        public string Source { get; set; }
        public string Element { get; set; }
        public string Id { get; set; }
        public bool AutoSelect { get; set; } = false;
        public bool ConfirmOnBlur { get; set; } = true;
        public string CssNameSpace { get; set; } = "autocomplete";
        public string DefaultValue { get; set; } = "";
        public string DisplayMenu { get; set; } = "inline";
        public int MinLength { get; set; } = 0;
        public string Name { get; set; } = "input-autocomplete";
        public string OnConfirm { get; set; } = "function(){}";
        public bool Required { get; set; } = false;
        public bool ShowAllValues { get; set; } = false;
        public bool ShowNoOptionsFound { get; set; } = true;
    
        public string ChildContent { get; set; }
        public string FunctionName { get; set; }
        public string AdditionalClass { get; set; }
    }
}
