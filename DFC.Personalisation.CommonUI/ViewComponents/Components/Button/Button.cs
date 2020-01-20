using System.Collections.Generic;
using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Components.Button
{
    [HtmlTargetElement("govukButton")]
    public class ButtonTagHelper : OptionalParamTagHelper, IButtonAttributes
    {
        public string Text { get; set; }
        public bool Disabled { get; set; }
        public string AdditionalClass { get; set; }

        public ButtonTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }


    public class Button : BaseViewComponent
    {
        private readonly string _additionalButtonCss;
        private readonly string _viewName;

        private readonly ButtonModel _model;

        public Button(string additionalButtonCss = null, string viewName = "Default.cshtml")
        {
            this._additionalButtonCss = additionalButtonCss;
            this._viewName = viewName;
            _model = new ButtonModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);


            _model.AdditionalClass = AutoPropsHelper.CombineClassProps(new List<string>
            {
                _model.AdditionalClass,
                _additionalButtonCss
            });

            return View($"/Views/Shared/Components/Button/{this._viewName}", _model);
        }
    }

    [HtmlTargetElement("govukStartButton")]
    public class StartButtonTagHelper : OptionalParamTagHelper, IButtonAttributes
    {
        public string Text { get; set; }
        public bool Disabled { get; set; }
        public string AdditionalClass { get; set; }
        public StartButtonTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class StartButton : Button
    {
        public StartButton()
         : base("govuk-button--start", "StartButton.cshtml")
        { }
    }

    [HtmlTargetElement("govukSecondaryButton")]
    public class SecondaryButtonTagHelper : OptionalParamTagHelper, IButtonAttributes
    {
        public string Text { get; set; }
        public bool Disabled { get; set; }
        public string AdditionalClass { get; set; }

        public SecondaryButtonTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class SecondaryButton : Button
    {
        public SecondaryButton()
         : base("govuk-button--secondary")
        { }
    }

    [HtmlTargetElement("govukWarningButton")]
    public class WarningButtonTagHelper : OptionalParamTagHelper, IButtonAttributes
    {
        public string Text { get; set; }
        public bool Disabled { get; set; }
        public string AdditionalClass { get; set; }

        public WarningButtonTagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class WarningButton : Button
    {
        public WarningButton()
         : base("govuk-button--warning")
        { }
    }
}
