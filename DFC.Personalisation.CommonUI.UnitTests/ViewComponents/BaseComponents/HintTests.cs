using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Hint;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents
{
    public class HintTests
    {
        [TestCase(nameof(HintModel.HintText), "The Text Field has Been Set")]
        public void WhenHintInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new Hint();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            HintModel resultModel = (HintModel)result.ViewData.Model;

            //Assert
            Assert.AreEqual(value, ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenHintTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new HintTagHelper(tagHelper);
            await ViewComponentTestHelper.CallTagHelper("Hint", tagHelper, componentTag);
        }
    }
}
