using DFC.Personalisation.CommonUI.ViewComponents.Components.BackLink;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using FluentAssertions;
using NSubstitute;

namespace DFC.Personalisation.CommonUI.UnitTests.ViewComponents
{
    public class BackLinkTests
    {

        [TestCase(nameof(BackLinkModel.LinkText),"The Text Field has Been Set")]
        [TestCase(nameof(BackLinkModel.Id), "The Text Field has Been Set")]
        [TestCase(nameof(BackLinkModel.LinkHref), "The Text Field has Been Set")]
        [TestCase(nameof(BackLinkModel.LinkTabIndex), "-1")]
        [TestCase(nameof(BackLinkModel.LinkTitle), "The Text Field has Been Set")]
        public void WhenBackLinkInvoked_ThenViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string,string>(){{key,value}};

            var component = new BackLink();
            component.ViewComponentContext = ViewComponentTestHelper.GeViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            BackLinkModel resultModel = (BackLinkModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
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
