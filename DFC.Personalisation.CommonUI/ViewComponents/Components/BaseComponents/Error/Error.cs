﻿using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Error
{
    [HtmlTargetElement("govukError")]
    public class ErrorTagHelper : OptionalParamTagHelper, IErrorAttributes
    {
        public string Text { get; set; }
        public bool Hidden { get; set; }
        public string Id { get; set; }
        public string AdditionalClass { get; set; }

        public ErrorTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class Error : BaseViewComponent
    {
        private readonly ErrorModel _model;

        private readonly string _viewName;

        public Error(string viewName = "Default.cshtml")
        {
            _viewName = viewName;
            _model = new ErrorModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);

            return View($"/Views/Shared/Components/BaseComponents/Error/{_viewName}", _model);
        }
    }



    [HtmlTargetElement("govukAutoCompleteError", ParentTag = "govukAutoComplete")]
    public class AutoCompleteErrorTagHelper : OptionalParamTagHelper, IErrorAttributes
    {
        public string Text { get; set; }
        public bool Hidden { get; set; }
        public string Id { get; set; }
        public string AdditionalClass { get; set; }

        public AutoCompleteErrorTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class AutoCompleteError : Error
    {
        public AutoCompleteError() : base()
        {

        }
    }

    [HtmlTargetElement("govukTextInputError", ParentTag = "govukTextInput")]
    public class TextInputErrorTagHelper : OptionalParamTagHelper, IErrorAttributes
    {
        public string Text { get; set; }
        public bool Hidden { get; set; }
        public string Id { get; set; }
        public string AdditionalClass { get; set; }

        public TextInputErrorTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class TextInputError : Error
    {
        public TextInputError() : base()
        {

        }
    }
}
