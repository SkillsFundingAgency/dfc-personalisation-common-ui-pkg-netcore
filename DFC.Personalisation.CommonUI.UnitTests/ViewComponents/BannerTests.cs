using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using DFC.Personalisation.CommonUI.ViewComponents.Components.Banner;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    public class BannerTests
    {
        
        [TestCase(nameof(BannerModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(BannerModel.HeaderText), "The Text Field has Been Set")]
        [TestCase(nameof(BannerModel.SubheaderText), "The Text Field has Been Set")]
        public void WhenPrimaryHeroBannerInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string,string>(){{key,value}};

            var component = new PrimaryHeroBanner();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            BannerModel resultModel = (BannerModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenPrimaryHeroBannerTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new PrimaryHeroBannerTagHelper(tagHelper)
            {
                Id = "Id",
                HeaderText = "HeaderText",
                SubheaderText = "SubHeaderText"
            };

            //For code coverage
            var id = componentTag.Id;
            var headerText = componentTag.HeaderText;
            var subHeading = componentTag.SubheaderText;
            await ViewComponentTestHelper.CallTagHelper("PrimaryHeroBanner", tagHelper, componentTag);
        }

    }
}
