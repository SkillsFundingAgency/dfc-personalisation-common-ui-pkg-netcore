using System.Collections.Generic;
using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.ErrorSummary.ErrorSummaryItem
{
    [HtmlTargetElement("govukErrorSummaryItem")]
    public class ErrorSummaryItemTagHelper : OptionalParamTagHelper, IErrorSummaryItemAttributes
    {
        public ErrorSummaryItemTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }

        public string Text { get; set; }
        public string Href { get; set; }
    }

    public class ErrorSummaryItem : BaseViewComponent
    {
        private readonly string viewName;
        private readonly ErrorSummaryItemModel _model;

        public ErrorSummaryItem(string viewName = "Default.cshtml")
        {
            this.viewName = viewName;
            _model = new ErrorSummaryItemModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);

            return View($"/Views/Shared/Components/ErrorSummary/ErrorSummaryItem/{this.viewName}", _model);
        }
    }
}
