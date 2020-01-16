using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.CheckBox
{
    public interface ICheckboxAttributes
    {
        string Label { get; set; }
        bool Checked { get; set; }
        string Name { get; set; }
        string Value { get; set; }
        string AdditionalClass { get; set; }
        string Id { get; set; }
    }
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

        public string Label { get; set; }
        public bool Checked { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string AdditionalClass { get; set; }
        public string Id { get; set; }

        public Checkbox(string viewName = "Default.cshtml")
        {
            this.viewName = viewName;
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            SetProps(values);

            var model = new CheckBoxModel()
            {
                Id = Id,
                Checked = Checked,
                Label = Label,
                Name = string.IsNullOrEmpty(Name) ? Id : Name,
                Value = Value,
                AdditionalClass = AdditionalClass
            };
            return View($"/Views/Shared/Components/CheckBox/{this.viewName}", model);
        }
    }
}
