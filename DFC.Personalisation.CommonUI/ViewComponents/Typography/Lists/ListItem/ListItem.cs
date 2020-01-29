using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents.Typography.Lists.ListItem
{
    [HtmlTargetElement("govukListItem", ParentTag = "govukBulletedList")]
    public class ListItemTagHelper : OptionalParamTagHelper, IListItemAttributes
    {
        public string Text { get; set; }

        public ListItemTagHelper(IViewComponentHelper viewComponentHelper) : base(viewComponentHelper)
        {
        }
    }

    public class ListItem : BaseViewComponent
    {
        private readonly string viewName;
        private readonly ListItemModel _model;


        public ListItem(string viewName = "Default.cshtml")
        {
            this.viewName = viewName;
            _model = new ListItemModel();
        }

        public virtual IViewComponentResult Invoke(Dictionary<string, string> values)
        {
            _model.SetProps(values);

            return View($"/Views/Shared/Typography/Lists/ListItem/{this.viewName}", _model);
        }
    }
}
