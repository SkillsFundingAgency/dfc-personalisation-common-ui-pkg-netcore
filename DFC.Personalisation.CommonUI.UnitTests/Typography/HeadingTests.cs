using DFC.Personalisation.CommonUI.ViewComponents.Typography.Heading;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using FluentAssertions;
using NSubstitute;

namespace DFC.Personalisation.CommonUI.UnitTests.Typography
{
    public class HeadingTests
    {
        [TestCase(nameof(HeadingModel.Text), "The Text Field has Been Set")]
        [TestCase(nameof(HeadingModel.Caption), "The Text Field has Been Set")]
        [TestCase(nameof(HeadingModel.Size), "xl")]
        [TestCase(nameof(HeadingModel.Tag), "h1")]
        public void WhenHeadingInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new Heading();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            HeadingModel resultModel = (HeadingModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [TestCase(nameof(HeadingModel.Size), "l")]
        [TestCase(nameof(HeadingModel.Tag), "h2")]
        public void WhenHeadingH2Invoked_ThenViewModelIsUpdated(string key, string expected)
        {
            var component = new HeadingH2();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(new Dictionary<string, string>()) as ViewViewComponentResult;
            HeadingModel resultModel = (HeadingModel)result.ViewData.Model;

            //Assert
            expected.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [TestCase(nameof(HeadingModel.Size), "m")]
        [TestCase(nameof(HeadingModel.Tag), "h3")]
        public void WhenHeadingH3Invoked_ThenViewModelIsUpdated(string key, string expected)
        {
            var component = new HeadingH3();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(new Dictionary<string, string>()) as ViewViewComponentResult;
            HeadingModel resultModel = (HeadingModel)result.ViewData.Model;

            //Assert
            expected.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [TestCase(nameof(HeadingModel.Size), "s")]
        [TestCase(nameof(HeadingModel.Tag), "h4")]
        public void WhenHeadingH4Invoked_ThenViewModelIsUpdated(string key, string expected)
        {
            var component = new HeadingH4();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(new Dictionary<string, string>()) as ViewViewComponentResult;
            HeadingModel resultModel = (HeadingModel)result.ViewData.Model;

            //Assert
            expected.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenHeadingHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new HeadingTagHelper(tagHelper);
            await ViewComponentTestHelper.CallTagHelper("Heading", tagHelper, componentTag);
        }

        [Test]
        public async Task WhenHeadingH2HelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new HeadingH2TagHelper(tagHelper);
            await ViewComponentTestHelper.CallTagHelper("HeadingH2", tagHelper, componentTag);
        }

        [Test]
        public async Task WhenHeadingH3HelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new HeadingH3TagHelper(tagHelper);
            await ViewComponentTestHelper.CallTagHelper("HeadingH3", tagHelper, componentTag);
        }

        [Test]
        public async Task WhenHeadingH4HelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new HeadingH4TagHelper(tagHelper);
            await ViewComponentTestHelper.CallTagHelper("HeadingH4", tagHelper, componentTag);
        }
    }
}
