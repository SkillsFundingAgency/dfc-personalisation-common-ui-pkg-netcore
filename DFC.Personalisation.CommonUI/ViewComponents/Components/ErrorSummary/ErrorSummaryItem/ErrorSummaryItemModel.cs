namespace DFC.Personalisation.CommonUI.ViewComponents.Components.ErrorSummary.ErrorSummaryItem
{
    public class ErrorSummaryItemModel :ViewModelBase, IErrorSummaryItemAttributes
    {
        public string Text { get; set; }
        public string Href { get; set; }
    }
}
