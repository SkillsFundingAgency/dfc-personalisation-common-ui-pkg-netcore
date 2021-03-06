﻿using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using DFC.Personalisation.CommonUI.ViewComponents.Components.BackLink;
using DFC.Personalisation.CommonUI.ViewComponents.Components.BaseComponents.Link;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    public class BackLinkTests
    {

        [TestCase(nameof(LinkModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.LinkHref), "The Text Field has Been Set")]
        [TestCase(nameof(LinkModel.LinkTabIndex), "-1")]
        [TestCase(nameof(LinkModel.LinkTitle), "The Text Field has Been Set")]
        public void WhenBackLinkInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string,string>(){{key,value}};

            var component = new BackLink();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            LinkModel resultModel = (LinkModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }

        [Test]
        public void WhenBackLinkInvoked_ThenViewModelLinkTextShouldBeSetToBackAsDefault()
        {
            var values = new Dictionary<string, string>() { };

            var component = new BackLink();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            LinkModel resultModel = (LinkModel)result.ViewData.Model;

            //Assert
            "Back".Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, "LinkText"));
        }

        [Test]
        public async Task WhenBackLinkTagHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new BackLinkTagHelper(tagHelper);
            await ViewComponentTestHelper.CallTagHelper("BackLink", tagHelper, componentTag);
        }
    }
}
