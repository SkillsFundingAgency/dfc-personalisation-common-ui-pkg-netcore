using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Link;
using DFC.Personalisation.CommonUI.ViewComponents.Components.ButtonLink;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    public class ButtonLinkTests
    {
        [TestCase(nameof(LinkModel.LinkText),"The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.LinkHref), "The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.LinkTabIndex), "-1")]
        [TestCase(nameof(LinkModel.LinkTitle), "The Text Field has Been Set")]
        public void WhenButtonLinkInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string,string>(){{key,value}};

            var component = new ButtonLink();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            LinkModel resultModel = (LinkModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenButtonLinkTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new ButtonLinkTagHelper(tagHelper)
            {
                AdditionalClass = "AdditionalClass",
                Id = "ID",
                LinkHref = "Link",
                LinkTabIndex = 1,
                LinkText = "Text",
                LinkTitle = "Title"
            };

            string additionalClass = componentTag.AdditionalClass;
            string id = componentTag.Id;
            string linkHref = componentTag.LinkHref;
            int linkTabIndex = componentTag.LinkTabIndex;
            string linkText = componentTag.LinkText;
            string linkTitle = componentTag.LinkTitle;

            await ViewComponentTestHelper.CallTagHelper("ButtonLink", tagHelper, componentTag);
        }

        [TestCase(nameof(LinkModel.LinkText),"The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.LinkHref), "The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.LinkTabIndex), "-1")]
        [TestCase(nameof(LinkModel.LinkTitle), "The Text Field has Been Set")]
        public void WhenStartButtonLinkInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string,string>(){{key,value}};

            var component = new StartButtonLink
            {
                ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext(),

            };

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            LinkModel resultModel = (LinkModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenStartButtonLinkTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new StartButtonLinkTagHelper(tagHelper)
            {
                AdditionalClass = "AdditionalClass",
                Id = "ID",
                LinkHref = "Link",
                LinkTabIndex = 1,
                LinkText = "Text",
                LinkTitle = "Title"
            };
            string additionalClass = componentTag.AdditionalClass;
            string id = componentTag.Id;
            string linkHref = componentTag.LinkHref;
            int linkTabIndex = componentTag.LinkTabIndex;
            string linkText = componentTag.LinkText;
            string linkTitle = componentTag.LinkTitle;
            await ViewComponentTestHelper.CallTagHelper("StartButtonLink", tagHelper, componentTag);
        }
    }
}
