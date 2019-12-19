using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Label;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents
{
    public class LabelTests
    {
        [TestCase(nameof(LabelModel.Text), "The Text Field has Been Set")]
        [TestCase(nameof(LabelModel.For), "The Text Field has Been Set")]
        public void WhenErrorInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new Label();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            LabelModel resultModel = (LabelModel)result.ViewData.Model;

            //Assert
            Assert.AreEqual(value, ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenErrorTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new LabelTagHelper(tagHelper);
            await ViewComponentTestHelper.CallTagHelper("Label", tagHelper, componentTag);
        }
    }
}
