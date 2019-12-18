using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DFC.Personalisation.CommonUI.Documentation.ViewComponents
{
    public class ExampleSectionModel
    {
        public string Title { get; set; }
        public string ExampleCode { get; set; }
        public string ComponentName { get; set; }
        public Dictionary<string, string> ComponentArgs { get; set; }
    }

    public class ExampleSectionViewComponent : ViewComponent
    {
        public virtual IViewComponentResult Invoke(string title = null, string exampleCode = null, string componentName = null, Dictionary<string, string> componentArgs = null)
        {
            var model = new ExampleSectionModel
            {
                Title = title,
                ExampleCode = exampleCode,
                ComponentName = componentName,
                ComponentArgs = componentArgs,
            };

            return View(model);
        }
    }
}
