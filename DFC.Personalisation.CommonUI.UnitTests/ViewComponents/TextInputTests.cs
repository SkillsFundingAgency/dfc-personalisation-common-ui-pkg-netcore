﻿using DFC.Personalisation.CommonUI.ViewComponents.Components.TextInput;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using FluentAssertions;
using NSubstitute;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    public class TextInputTests
    {
        [TestCase(nameof(TextInputModel.ChildContent), "The Text Field has Been Set")]
        [TestCase(nameof(TextInputModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(TextInputModel.HasError), "True")]
        [TestCase(nameof(TextInputModel.HintText), "-1")]
        [TestCase(nameof(TextInputModel.ErrorMessage), "The Text Field has Been Set")]
        public void WhenTextInputInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new TextInput();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            TextInputModel resultModel = (TextInputModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenTextInputHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new TextInputTagHelper(tagHelper);
            await ViewComponentTestHelper.CallTagHelper("TextInput", tagHelper, componentTag);
        }
    }
}
