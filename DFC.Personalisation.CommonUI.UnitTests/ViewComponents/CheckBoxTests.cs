﻿using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using DFC.Personalisation.CommonUI.ViewComponents.Components.CheckBox;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    public class CheckBoxTests
    {
        [TestCase(nameof(CheckBoxModel.Checked), "True")]
        [TestCase(nameof(CheckBoxModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(CheckBoxModel.Label), "True")]
        [TestCase(nameof(CheckBoxModel.Name), "name test")]
        [TestCase(nameof(CheckBoxModel.Value), "The Text Field has Been Set")]
        [TestCase(nameof(CheckBoxModel.AdditionalClass), "Additional Class")]
        public void WhenCheckBoxInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new Checkbox();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            CheckBoxModel resultModel = (CheckBoxModel)result.ViewData.Model;

            //Assert
            Assert.AreEqual(value, ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenCheckBoxHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new CheckboxTagHelper(tagHelper)
            {
                AdditionalClass = "AdditionalClass",
                Checked = true,
                Id = "Id",
                Label = "Label",
                Name = "Name",
                Value = "Value"
            };
            string additionalClass = componentTag.AdditionalClass;
            bool isChecked = componentTag.Checked;
            string id = componentTag.Id;
            string label = componentTag.Label;
            string name = componentTag.Name;
            string value = componentTag.Value;

            await ViewComponentTestHelper.CallTagHelper("Checkbox", tagHelper, componentTag);
        }
    }
}