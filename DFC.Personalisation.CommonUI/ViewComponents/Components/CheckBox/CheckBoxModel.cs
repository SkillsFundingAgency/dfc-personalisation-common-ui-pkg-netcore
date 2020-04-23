namespace DFC.Personalisation.CommonUI.ViewComponents.Components.CheckBox
{
    public class CheckBoxModel : ViewModelBase, ICheckboxAttributes
    {
        public string Label { get; set; }
        public bool Checked { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string AdditionalClass { get; set; }
        public string Id { get; set; }
        public bool Disabled { get; set; }
    }
}
