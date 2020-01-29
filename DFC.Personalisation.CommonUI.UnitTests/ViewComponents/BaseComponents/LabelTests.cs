using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Label;
using FluentAssertions;
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
        public void WhenLabelInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new Label();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            LabelModel resultModel = (LabelModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [TestCase(nameof(LabelModel.AdditionalClass), "test-1")]
        public void WhenRadioLabelInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new RadioLabel();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            LabelModel resultModel = (LabelModel)result.ViewData.Model;

            //Assert
            resultModel.AdditionalClass.Should().Contain(value);
        }

        [Test]
        public async Task WhenLabelTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new LabelTagHelper(tagHelper)
            {
                Text = "LabelText", For = "ForText", AdditionalClass = "AdditionalClass"
            };

            await ViewComponentTestHelper.CallTagHelper("Label", tagHelper, componentTag);
        }

        [Test]
        public async Task WhenRadioLabelTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new RadioLabelTagHelper(tagHelper)
            {
                Text = "LabelText", For = "ForText", AdditionalClass = "AdditionalClass"
            };
            await ViewComponentTestHelper.CallTagHelper("RadioLabel", tagHelper, componentTag);
        }

        [Test]
        public async Task WhenAutoCompleteLabelTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new AutoCompleteLabelTagHelper(tagHelper)
            {
                Text = "LabelText", For = "ForText", AdditionalClass = "AdditionalClass"
            };
            await ViewComponentTestHelper.CallTagHelper("AutoCompleteLabel", tagHelper, componentTag);
        }
    }
}
