using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Error
{
    [HtmlTargetElement("govukError", ParentTag = "govukTextInput")]
    public class ErrorTagHelper : OptionalParamTagHelper
    {
        public ErrorTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class Error : BaseViewComponent
    {
        public string Text { get; set; }
        public string Id { get; set; }
        private readonly string _additionalClass;
        private readonly string _viewName;

        public Error(string additionalClass = null, string viewName = "Default.cshtml")
        {
            _additionalClass = additionalClass;
            _viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new ErrorModel()
            {
                Text= Text,
                AdditionalClass = _additionalClass,
                Id = Id
            };
            return View($"/Views/Shared/Components/BaseComponents/Error/{_viewName}", model);
        }
    }
}
