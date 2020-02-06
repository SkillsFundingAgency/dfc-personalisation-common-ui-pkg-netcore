using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using DFC.Personalisation.CommonUI.ViewComponents.Components.ErrorSummary;
using DFC.Personalisation.CommonUI.ViewComponents.Components.ErrorSummary.ErrorSummaryItem;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    public class ErrorSummaryTests
    {

        [TestCase(nameof(ErrorSummaryModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(ErrorSummaryModel.ChildContent), "The Text Field has Been Set")]
        public void WhenErrorSummaryInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new ErrorSummary();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            ErrorSummaryModel resultModel = (ErrorSummaryModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [TestCase(nameof(ErrorSummaryItemModel.Text), "The Text Field has Been Set")]
        [TestCase(nameof(ErrorSummaryItemModel.Href), "The Text Field has Been Set")]
        public void WhenErrorSummaryItemInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new ErrorSummaryItem();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            ErrorSummaryItemModel resultModel = (ErrorSummaryItemModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenErrorSummaryHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new ErrorSummaryTagHelper(tagHelper)
            {
                Id = "Id",
            };

            await ViewComponentTestHelper.CallTagHelper("ErrorSummary", tagHelper, componentTag);
        }

        [Test]
        public async Task WhenErrorSummaryItemHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new ErrorSummaryItemTagHelper(tagHelper)
            {
               Href = "href",
               Text = "text"
            };

            await ViewComponentTestHelper.CallTagHelper("ErrorSummaryItem", tagHelper, componentTag);
        }


    }
}
