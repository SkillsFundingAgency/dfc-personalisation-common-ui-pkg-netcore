namespace DFC.Personalisation.CommonUI.ViewComponents.Components.Button
{
    public class ButtonModel: ViewModelBase, IButtonAttributes
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public bool Disabled { get; set; }

        public string AdditionalClass { get; set; }
    }
}
