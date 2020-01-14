using System.Collections.Generic;
using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DFC.Personalisation.CommonUI.ViewComponents.Typography.Heading
{
    [HtmlTargetElement("govukHeadingH1")]
    public class HeadingTagHelper : OptionalParamTagHelper
    {
        public HeadingTagHelper(IViewComponentHelper viewComponentHelper) 
            : base(viewComponentHelper)
        {
        }
    }

    public class Heading : BaseViewComponent
    {
        private readonly string size;

        public string Text { get; set; }
        public string Caption { get; set; }
        public string AdditionalClass { get; set; }
        public Heading(string size = "xl")
        {
            this.size = size;
        }


        public virtual IViewComponentResult Invoke(Dictionary<string,string> values)
        {
            SetProps(values);
            
            var model = new HeadingModel()
            {
                Tag = "h1",
                Size = this.size,
                Text = this.Text,
                Caption = this.Caption,
                AdditionalClass = this.AdditionalClass
            };

            switch(this.size)
            {
                case "l":
                    model.Tag = "h2";
                    break;
                case "m":
                    model.Tag = "h3";
                    break;
                case "s":
                    model.Tag = "h4";
                    model.Caption = null; // there is no caption style for h4 in gds
                    break;
                default:
                    model.Tag = "h1";
                    model.Size = "xl";
                    break;
            }

            return View("/Views/Shared/Typography/Heading/Default.cshtml", model);
        }
    }


    [HtmlTargetElement("govukHeadingH2")]
    public class HeadingH2TagHelper : OptionalParamTagHelper
    {
        public HeadingH2TagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }
    
    public class HeadingH2 : Heading
    {
        public HeadingH2()
         : base("l")
        {}
    }

    [HtmlTargetElement("govukHeadingH3")]
    public class HeadingH3TagHelper : OptionalParamTagHelper
    {
        public HeadingH3TagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class HeadingH3 : Heading
    {
        public HeadingH3()
         : base("m")
        { }
    }

    [HtmlTargetElement("govukHeadingH4")]
    public class HeadingH4TagHelper : OptionalParamTagHelper
    {
        public HeadingH4TagHelper(IViewComponentHelper viewComponentHelper)
            : base(viewComponentHelper)
        {
        }
    }

    public class HeadingH4 : Heading
    {
        public HeadingH4()
         : base("s")
        { }
    }
}
