using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.CheckBox
{
    
    [HtmlTargetElement("govukCheckbox")]
    public class CheckboxTagHelper : OptionalParamTagHelper, ICheckboxAttributes
    {
        public string Label { get; set; }
        public bool Checked { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string AdditionalClass { get; set; }
        public string Id { get; set; }

        public CheckboxTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class Checkbox : BaseViewComponent
    {
        private readonly string viewName;

        private readonly CheckBoxModel _model;

        public Checkbox(string viewName = "Default.cshtml")
        {
            this.viewName = viewName;
            _model = new CheckBoxModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);
            _model.Name = string.IsNullOrEmpty(_model.Name) ? _model.Id : _model.Name;
            return View($"/Views/Shared/Components/CheckBox/{this.viewName}", _model);
        }
    }
}
