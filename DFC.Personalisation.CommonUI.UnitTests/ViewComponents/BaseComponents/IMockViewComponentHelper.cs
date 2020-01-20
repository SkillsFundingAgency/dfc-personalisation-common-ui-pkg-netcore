using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents
{
    public interface IMockViewComponentHelper : IViewComponentHelper, IViewContextAware
    {
    }
}
