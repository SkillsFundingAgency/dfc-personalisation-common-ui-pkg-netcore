using System.Collections.Generic;
using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using DFC.Personalisation.CommonUI.ViewComponents.Components.RadioButton;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    public class RadioButtonTests
    {
        [Test]
        public async Task WhenRadioButtonHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new RadioButtonTagHelper(tagHelper)
            {
                Id = "Id",
                Value = "Value",
                AdditionalClass = "AdditionalClass"
            };
            string id = componentTag.Id;
            string value = componentTag.Value;
            string additionalClass = componentTag.AdditionalClass;

            await ViewComponentTestHelper.CallTagHelper("RadioButton", tagHelper, componentTag);
        }

        [TestCase(nameof(RadioButtonModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(RadioButtonModel.Value), "The Text Field has Been Set")]
        public void WhenErrorInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new RadioButton();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            RadioButtonModel resultModel = (RadioButtonModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

    }
}
