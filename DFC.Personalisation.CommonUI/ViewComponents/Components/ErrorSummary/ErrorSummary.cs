using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.ErrorSummary
{

    [HtmlTargetElement("govukErrorSummary")]
    public class ErrorSummaryTagHelper : OptionalParamTagHelper, IErrorSummaryAttributes
    {
        public ErrorSummaryTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await ProcessAsyncWithChildren(context, output, nameof(ErrorSummaryModel.ChildContent));
        }

        public string Id { get; set; }
        public bool Hidden { get; set; }
    }

    public class ErrorSummary : BaseViewComponent
    {
        private readonly string _viewName;
        private readonly ErrorSummaryModel _model;

        public ErrorSummary(string viewName = "Default.cshtml")
        {
            this._viewName = viewName;
            _model = new ErrorSummaryModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);
            return View($"/Views/Shared/Components/ErrorSummary/{this._viewName}", _model);
        }
    }
}
