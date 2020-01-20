﻿using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Hint;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;

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
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenHintTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new HintTagHelper(tagHelper);
            componentTag.HintText = "HintText";
            componentTag.AdditionalClass = "AdditionalClass";
            string hintText = componentTag.HintText;
            string additionalClass = componentTag.AdditionalClass;

            await ViewComponentTestHelper.CallTagHelper("Hint", tagHelper, componentTag);
        }
    }
}
