namespace DFC.Personalisation.CommonUI.ViewComponents.Components.ErrorSummary
{
    public class ErrorSummaryModel :ViewModelBase, IErrorSummaryAttributes
    {
        public string Id { get; set; }
        public string ChildContent { get; set; }
        public bool Hidden { get; set; }
    }
}
