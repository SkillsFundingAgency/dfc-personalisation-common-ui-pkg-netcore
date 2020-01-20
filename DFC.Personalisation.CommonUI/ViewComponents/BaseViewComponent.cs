using DFC.Personalisation.CommonUI.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents
{
    public abstract class BaseViewComponent: ViewComponent
    {
        protected void SetProps(Dictionary<string,string> options)
        {
           AutoPropsHelper.SetProps(options,this);
        }
    }
}
