using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DFC.Personalisation.CommonUI.ViewComponents.Components.AutoComplete
{
    [HtmlTargetElement("govukAutoComplete")]
    [RestrictChildren("govukAutoCompleteLabel", "govukAutoCompleteError")]

    public class AutoCompleteTagHelper : OptionalParamTagHelper, IAutoComplete
    {

        public string Source { get; set; }
        public string Element { get; set; }
        public string Id { get; set; }
        public bool AutoSelect { get; set; }
        public bool ConfirmOnBlur { get; set; }
        public string CssNameSpace { get; set; }
        public string DefaultValue { get; set; }
        public string DisplayMenu { get; set; }
        public int MinLength { get; set; }
        public string Name { get; set; }
        public string OnConfirm { get; set; }
        public bool Required { get; set; }
        public bool ShowAllValues { get; set; }
        public bool ShowNoOptionsFound { get; set; }
        public string FunctionName { get; set; }
        public string AdditionalClass { get; set; }

        public AutoCompleteTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {

        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await ProcessAsyncWithChildren(context, output, nameof(AutoCompleteModel.ChildContent));
        }

    }

    public class AutoComplete : BaseViewComponent
    {
        private readonly string _viewName;
        private readonly AutoCompleteModel _model;

        public AutoComplete(string viewName = "Default.cshtml")
        {
            _viewName = viewName;
            _model = new AutoCompleteModel();
        }



        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);

            return View($"/Views/Shared/Components/AutoComplete/{this._viewName}", _model);
        }
    }
}
