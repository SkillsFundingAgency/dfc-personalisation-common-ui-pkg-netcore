using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.ViewComponents.Typography.Lists
{

    [HtmlTargetElement("govukBulletedList")]
    [RestrictChildren("govukListItem")]
    public class BulletedListTagHelper : OptionalParamTagHelper, IListAttributes
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string AdditionalClass { get; set; }

        private readonly IViewComponentHelper _viewComponentHelper;
        public BulletedListTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await ProcessAsyncWithChildren(context, output, nameof(ListModel.ChildContent));
        }

    }

    public class BulletedList : BaseViewComponent
    {
        private readonly string _viewName;
        private readonly string _additionalCss;
        private readonly ListModel _model;

        public BulletedList(string additionalCss = "govuk-list--bullet", string viewName = "BulletedList.cshtml")
        {
            _viewName = viewName;
            _additionalCss = additionalCss;
            _model = new ListModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);
            _model.AdditionalClass = _additionalCss;

            return View($"/Views/Shared/Typography/Lists/{_viewName}", _model);
        }
    }
}
