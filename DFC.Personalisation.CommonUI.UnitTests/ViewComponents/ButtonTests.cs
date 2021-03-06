﻿using DFC.Personalisation.CommonUI.ViewComponents.Components.Button;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using FluentAssertions;
using NSubstitute;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    class ButtonTests
    {
        [TestCase(nameof(ButtonModel.Id), "Test Id")]
        [TestCase(nameof(ButtonModel.Text), "Test Text")]
        [TestCase(nameof(ButtonModel.Disabled), "True")]
        public void WhenButtonInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new Button();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            ButtonModel resultModel = (ButtonModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [TestCase(nameof(ButtonModel.AdditionalClass), "govuk-button--start")]
        public void WhenStartButtonInvoked_ThenViewModelIsUpdated(string key, string expected)
        {
            var component = new StartButton();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(new Dictionary<string, string>()) as ViewViewComponentResult;
            ButtonModel resultModel = (ButtonModel)result.ViewData.Model;

            //Assert
            expected.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [TestCase(nameof(ButtonModel.AdditionalClass), "govuk-button--secondary")]
        public void WhenSecondaryButtonInvoked_ThenViewModelIsUpdated(string key, string expected)
        {
            var component = new SecondaryButton();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(new Dictionary<string, string>()) as ViewViewComponentResult;
            ButtonModel resultModel = (ButtonModel)result.ViewData.Model;

            //Assert
            resultModel.AdditionalClass.Should().BeEquivalentTo(expected);
        }

        [TestCase(nameof(ButtonModel.AdditionalClass), "govuk-button--warning")]
        public void WhenWarningButtonInvoked_ThenViewModelIsUpdated(string key, string expected)
        {
            
            var component = new WarningButton();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(new Dictionary<string, string>()) as ViewViewComponentResult;
            ButtonModel resultModel = (ButtonModel)result.ViewData.Model;

            //Assert
            expected.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenButtonHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new ButtonTagHelper(tagHelper)
            { 
                Id = "Id",
                AdditionalClass = "AdditionalClass",
                Disabled = false,
                Text = "ButtonText"
            };
            string id = componentTag.Id;
            string additionalClass = componentTag.AdditionalClass;
            bool disabled = componentTag.Disabled;
            string text = componentTag.Text;

            await ViewComponentTestHelper.CallTagHelper("Button", tagHelper, componentTag);
        }

        [Test]
        public async Task WhenStartButtonHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new StartButtonTagHelper(tagHelper)
            { 
                Id = "id",
                AdditionalClass = "AdditionalClass",
                Disabled = false,
                Text = "ButtonText"
            };
            string id = componentTag.Id;
            string additionalClass = componentTag.AdditionalClass;
            bool disabled = componentTag.Disabled;
            string text = componentTag.Text;
            await ViewComponentTestHelper.CallTagHelper("StartButton", tagHelper, componentTag);
        }

        [Test]
        public async Task WhenSecondaryButtonHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new SecondaryButtonTagHelper(tagHelper)
            {
                Id = "Id",
                AdditionalClass = "AdditionalClass",
                Disabled = false,
                Text = "ButtonText"
            };
            string id = componentTag.Id;
            string additionalClass = componentTag.AdditionalClass;
            bool disabled = componentTag.Disabled;
            string text = componentTag.Text;
            await ViewComponentTestHelper.CallTagHelper("SecondaryButton", tagHelper, componentTag);
        }

        [Test]
        public async Task WhenWarningButtonHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new WarningButtonTagHelper(tagHelper)
            {
                Id = "Id",
                AdditionalClass = "AdditionalClass",
                Disabled = false,
                Text = "ButtonText"
            };
            string id = componentTag.Id;
            string additionalClass = componentTag.AdditionalClass;
            bool disabled = componentTag.Disabled;
            string text = componentTag.Text;

            await ViewComponentTestHelper.CallTagHelper("WarningButton", tagHelper, componentTag);
        }
    }
}
