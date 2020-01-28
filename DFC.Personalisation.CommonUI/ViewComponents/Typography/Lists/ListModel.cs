using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace DFC.Personalisation.CommonUI.ViewComponents.Typography.Lists
{
    public class ListModel : ViewModelBase, IListAttributes
    {
        public string AdditionalClass { get; set; }
        public string Id { get; set; }
        
        public string ChildContent { get; set; }
        public string Text { get; set; }
    }
   
}
