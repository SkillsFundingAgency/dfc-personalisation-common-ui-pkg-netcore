﻿using System;
using System.Collections.Generic;
using System.Text;
using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.CheckBox
{
    [HtmlTargetElement("govukCheckBox")]
   public class CheckboxTagHelper : OptionalParamTagHelper
    {
        public CheckboxTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class Checkbox : BaseViewComponent
    {
        private readonly string _additionalCss;
        private readonly string viewName;

        public string Label { get; set; }
        public bool Checked { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string AdditionalClass { get; set; }
        public string Id { get; set; }

        public Checkbox(string additionalCss = null, string viewName = "Default.cshtml")
        {
            this._additionalCss = additionalCss;
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
                Name = Name,
                Value = Value,
                AdditionalClass = this._additionalCss,
            };
            return View($"/Views/Shared/Components/Button/{this.viewName}", model);
        }
    }
}