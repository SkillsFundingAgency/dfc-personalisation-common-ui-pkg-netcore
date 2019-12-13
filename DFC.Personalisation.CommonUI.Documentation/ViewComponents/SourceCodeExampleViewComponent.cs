using Microsoft.AspNetCore.Mvc;

namespace DFC.Personalisation.CommonUI.Documentation.ViewComponents
{
    public class SourceCodeExampleModel
    {
        public string Code { get; set; }
    }

    public class SourceCodeExampleViewComponent : ViewComponent
    {
        public virtual IViewComponentResult Invoke(string code)
        {
            var model = new SourceCodeExampleModel
            {
                Code = code
            };
            
            return View(model);
        }
    }
}
