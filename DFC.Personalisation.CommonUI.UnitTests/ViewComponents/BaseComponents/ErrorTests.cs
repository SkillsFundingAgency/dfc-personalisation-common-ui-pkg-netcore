using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Error;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents
{
    public class ErrorTests
    {
        [TestCase(nameof(ErrorModel.Text), "The Text Field has Been Set")]
        [TestCase(nameof(ErrorModel.Id), "The Text Field has Been Set")]
        public void WhenErrorInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new Error();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            ErrorModel resultModel = (ErrorModel)result.ViewData.Model;

            //Assert
            Assert.AreEqual(value, ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenErrorTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new ErrorTagHelper(tagHelper);
            await ViewComponentTestHelper.CallTagHelper("Error", tagHelper, componentTag);
        }
    }
}
