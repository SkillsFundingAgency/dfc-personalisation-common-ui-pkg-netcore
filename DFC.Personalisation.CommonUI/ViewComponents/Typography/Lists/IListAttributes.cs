using System;
using System.Collections.Generic;
using System.Text;
using DFC.Personalisation.CommonUI.Interfaces;

namespace DFC.Personalisation.CommonUI.ViewComponents.Typography.Lists
{
    public interface IListAttributes : IAdditional, IHtmlBase
    {
        string Text { get; set; }
    }
}
