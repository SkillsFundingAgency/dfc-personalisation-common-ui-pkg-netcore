using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Link;
using FluentAssertions;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents
{
    public class LinkTests
    {
        [TestCase(nameof(LinkModel.LinkText), "The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.LinkHref), "The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.LinkTabIndex), "-1")]
        [TestCase(nameof(LinkModel.LinkTitle), "The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.Class), "The Text Field has Been Set")]
        public void WhenLinkInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new Link();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            LinkModel resultModel = (LinkModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public async Task WhenLinkTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new LinkTagHelper(tagHelper)
            {
                AdditionalClass = "AdditionalClass",
                Class = "Class",
                Id = "Id",
                LinkHref = "LinkHref",
                LinkTabIndex = 1,
                LinkText = "LinkText",
                LinkTitle = "LinkTitle"
            };
            string additionalClass = componentTag.AdditionalClass;
            string id = componentTag.Id;
            string linkHref = componentTag.LinkHref;
            int linkTabIndex = componentTag.LinkTabIndex;
            string linkText = componentTag.LinkText;
            string linkTitle = componentTag.LinkTitle;
            string classProp = componentTag.Class;
     
            
            await ViewComponentTestHelper.CallTagHelper("Link", tagHelper, componentTag);
        }

    }
}
