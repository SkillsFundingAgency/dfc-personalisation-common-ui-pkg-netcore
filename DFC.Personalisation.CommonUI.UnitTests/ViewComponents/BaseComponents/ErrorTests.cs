using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Error;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents
{
    public class ErrorTests
    {
        [TestCase(nameof(ErrorModel.Text), "The Text Field has Been Set")]
        [TestCase(nameof(ErrorModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(ErrorModel.AdditionalClass), "Additional Class")]
        [TestCase(nameof(ErrorModel.Hidden), "True")]
        public void WhenErrorInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new Error();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            ErrorModel resultModel = (ErrorModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenErrorTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new ErrorTagHelper(tagHelper);
            componentTag.AdditionalClass = "AdditionalClass";
            componentTag.Id = "Id";
            componentTag.Text = "ThisIsText";
            string additionalClass = componentTag.AdditionalClass;
            string id = componentTag.Id;
            string text = componentTag.Text;

            await ViewComponentTestHelper.CallTagHelper("Error", tagHelper, componentTag);
        }

        [TestCase(nameof(ErrorModel.Text), "The Text Field has Been Set")]
        [TestCase(nameof(ErrorModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(ErrorModel.AdditionalClass), "Additional Class")]
        [TestCase(nameof(ErrorModel.Hidden), "True")]
        public void WhenAutoCompleteErrorInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new AutoCompleteError();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            ErrorModel resultModel = (ErrorModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }


        [Test]
        public async Task WhenAutoCompleteErrorTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new AutoCompleteErrorTagHelper(tagHelper);
            componentTag.AdditionalClass = "AdditionalClass";
            componentTag.Id = "Id";
            componentTag.Text = "ThisIsText";
            componentTag.Hidden = true;
            string additionalClass = componentTag.AdditionalClass;
            string id = componentTag.Id;
            string text = componentTag.Text;
            bool hidden = componentTag.Hidden;

            await ViewComponentTestHelper.CallTagHelper("AutoCompleteError", tagHelper, componentTag);
        }
    }
}
