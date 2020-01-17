using DFC.Personalisation.CommonUI.TagHelpers;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.ViewComponents
{
    public class ViewModelBase
    {
        public void SetProps(Dictionary<string, string> options)
        {
            AutoPropsHelper.SetProps(options, this);
        }
    }
}
