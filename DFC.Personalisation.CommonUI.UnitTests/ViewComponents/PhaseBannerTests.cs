using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Collections.Generic;
using DFC.Personalisation.CommonUI.ViewComponents.Components.PhaseBanner;
using FluentAssertions;
using NUnit.Framework;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    public class PhaseBannerTests
    {
        [TestCase(nameof(PhaseBannerModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(PhaseBannerModel.FeedbackHref), "The Text Field has Been Set")]
        [TestCase(nameof(PhaseBannerModel.Phase), "Beta")]
        public void When_PhaseBannerInvoked_Then_ViewModelIsUpdated(string key, string value)
        {
            // Arrange.
            var values = new Dictionary<string, string>() { { key, value } };
            var component = new PhaseBanner
            {
                ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext()
            };

            // Act.
            var result = component.Invoke(values) as ViewViewComponentResult;
            var resultModel = result.ViewData.Model as PhaseBannerModel;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public void When_PhaseBannerInvokedWithNoAttributes_Then_DefaultValuesShouldBeUsed()
        {
            // Arrange.
            var values = new Dictionary<string, string>() { };
            var component = new PhaseBanner()
            {
                ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext()
            };
            
            // Act.
            var result = component.Invoke(values) as ViewViewComponentResult;
            var resultModel = result.ViewData.Model as PhaseBannerModel;

            //Assert
            resultModel.Id.Should().BeNull();
            resultModel.Phase.Should().Be(IPhaseBanner.ProjectPhase.Alpha);
            resultModel.FeedbackHref.Should().Be("#");
        }
    }
}
