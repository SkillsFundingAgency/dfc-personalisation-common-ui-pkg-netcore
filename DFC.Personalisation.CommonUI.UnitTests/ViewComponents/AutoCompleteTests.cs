﻿using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using DFC.Personalisation.CommonUI.ViewComponents.Components.AutoComplete;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    public class AutoCompleteTests
    {
        [TestCase(nameof(AutoCompleteModel.Source), "True")]
        [TestCase(nameof(AutoCompleteModel.Element), "The Text Field has Been Set")]
        [TestCase(nameof(AutoCompleteModel.Id), "True")]
        [TestCase(nameof(AutoCompleteModel.AutoSelect), "True")]
        [TestCase(nameof(AutoCompleteModel.ConfirmOnBlur), "True")]
        [TestCase(nameof(AutoCompleteModel.CssNameSpace), "name test")]
        [TestCase(nameof(AutoCompleteModel.DefaultValue), "name test")]
        [TestCase(nameof(AutoCompleteModel.DisplayMenu), "Inline")]
        [TestCase(nameof(AutoCompleteModel.MinLength), "1")]
        [TestCase(nameof(AutoCompleteModel.Name), "name test")]
        [TestCase(nameof(AutoCompleteModel.OnConfirm), "name test")]
        [TestCase(nameof(AutoCompleteModel.Required), "True")]
        [TestCase(nameof(AutoCompleteModel.ShowAllValues), "True")]
        [TestCase(nameof(AutoCompleteModel.ShowNoOptionsFound), "True")]
        [TestCase(nameof(AutoCompleteModel.FunctionName), "name test")]
        [TestCase(nameof(AutoCompleteModel.AdditionalClass), "name test")]
        public void WhenCheckBoxInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new AutoComplete();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            AutoCompleteModel resultModel = (AutoCompleteModel)result.ViewData.Model;

            //Assert
            Assert.AreEqual(value, ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenCheckBoxHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new AutoCompleteTagHelper(tagHelper)
            {
                Id = "id",
                AutoSelect = true,
                ConfirmOnBlur = true,
                CssNameSpace = "",
                DefaultValue = "",
                DisplayMenu = "",
                Element = "",
                FunctionName = "",
                MinLength = 1,
                ShowNoOptionsFound = true,
                Name = "",
                Required = true,
                ShowAllValues = true,
                OnConfirm = "",
                Source = "",
                AdditionalClass = ""
            };
            string id = componentTag.Id;
            bool autoSelect = componentTag.AutoSelect;
            bool confirmOnBlur = componentTag.ConfirmOnBlur;
            string cssNamespace = componentTag.CssNameSpace;
            string defaultValue = componentTag.DefaultValue;
            string displayMenu = componentTag.DisplayMenu;
            string element = componentTag.Element;
            string functionName = componentTag.FunctionName;
            int minLength = componentTag.MinLength;
            bool showNoOptionsFound = componentTag.ShowNoOptionsFound;
            string name = componentTag.Name;
            bool required = componentTag.Required;
            bool showAllValues = componentTag.ShowAllValues;
            string onConfirm = componentTag.OnConfirm;
            string source = componentTag.Source;
            string additionalClass = componentTag.AdditionalClass;

            await ViewComponentTestHelper.CallTagHelper("AutoComplete", tagHelper, componentTag);
        }
    }
}
