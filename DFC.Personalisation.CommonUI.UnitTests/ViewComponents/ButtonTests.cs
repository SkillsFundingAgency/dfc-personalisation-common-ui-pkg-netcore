using DFC.Personalisation.CommonUI.ViewComponents.Components.Button;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NUnit.Framework;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    class ButtonTests
    {
        [TestCase(nameof(ButtonModel.Text), "Test Text")]
        [TestCase(nameof(ButtonModel.Disabled), "True")]
        public void WhenButtonInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new Button();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            ButtonModel resultModel = (ButtonModel)result.ViewData.Model;

            //Assert
            Assert.AreEqual(value, ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [TestCase(nameof(ButtonModel.AdditionalClass), "govuk-button--start")]
        public void WhenStartButtonInvoked_ThenViewModelIsUpdated(string key, string expected)
        {
            var component = new StartButton();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(new Dictionary<string, string>()) as ViewViewComponentResult;
            ButtonModel resultModel = (ButtonModel)result.ViewData.Model;

            //Assert
            Assert.AreEqual(expected, ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [TestCase(nameof(ButtonModel.AdditionalClass), "govuk-button--secondary")]
        public void WhenSecondaryButtonInvoked_ThenViewModelIsUpdated(string key, string expected)
        {
            var component = new SecondaryButton();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(new Dictionary<string, string>()) as ViewViewComponentResult;
            ButtonModel resultModel = (ButtonModel)result.ViewData.Model;

            //Assert
            Assert.AreEqual(expected, ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [TestCase(nameof(ButtonModel.AdditionalClass), "govuk-button--warning")]
        public void WhenWarningButtonInvoked_ThenViewModelIsUpdated(string key, string expected)
        {
            
            var component = new WarningButton();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(new Dictionary<string, string>()) as ViewViewComponentResult;
            ButtonModel resultModel = (ButtonModel)result.ViewData.Model;

            //Assert
            Assert.AreEqual(expected, ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }
    }
}
