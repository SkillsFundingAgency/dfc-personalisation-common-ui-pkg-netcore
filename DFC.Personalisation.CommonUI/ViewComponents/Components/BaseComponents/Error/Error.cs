using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Error
{
    public interface IErrorAttributes
    {
        string Text { get; set; }
        string Id { get; set; }
        string AdditionalClass { get; set; }
    }
    [HtmlTargetElement("govukError", ParentTag = "govukTextInput")]
    public class ErrorTagHelper : OptionalParamTagHelper, IErrorAttributes
    {
        public string Text { get; set; }
        public string Id { get; set; }
        public string AdditionalClass { get; set; }

        public ErrorTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class Error : BaseViewComponent, IErrorAttributes
    {
        public string Text { get; set; }
        public string Id { get; set; }
        public string AdditionalClass { get; set; }

        private readonly string _viewName;

        public Error(string viewName = "Default.cshtml")
        {
            _viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new ErrorModel()
            {
                Text= Text,
                AdditionalClass = AdditionalClass,
                Id = Id
            };
            return View($"/Views/Shared/Components/BaseComponents/Error/{_viewName}", model);
        }
    }
}
