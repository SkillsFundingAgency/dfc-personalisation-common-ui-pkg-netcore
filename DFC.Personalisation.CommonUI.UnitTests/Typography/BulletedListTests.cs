using DFC.Personalisation.CommonUI.UnitTests.ViewComponents.BaseComponents;
using DFC.Personalisation.CommonUI.ViewComponents.Typography.Lists;
using DFC.Personalisation.CommonUI.ViewComponents.Typography.Lists.ListItem;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DFC.Personalisation.CommonUI.UnitTests.Typography
{
    public class BulletedListTests
    {
        [Test]
        public async Task WhenBulletedListHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new BulletedListTagHelper(tagHelper)
            {
                Id = "Id",
                AdditionalClass = "AdditionalClass",
                Text = "Test"
            };
            string id = componentTag.Id;
            string additionalClass = componentTag.AdditionalClass;
            string text = componentTag.Text;

            await ViewComponentTestHelper.CallTagHelper("BulletedList", tagHelper, componentTag);
        }
        
        [TestCase(nameof(ListModel.Id), "The Id Field has Been Set")]
        [TestCase(nameof(ListModel.Text), "The Text Field has Been Set")]
        [TestCase(nameof(ListModel.AdditionalClass), "govuk-list--bullet")]
        [TestCase(nameof(ListModel.ChildContent), "The ChildContent Field has Been Set")]
        public void WhenBulletedListInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new BulletedList();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            ListModel resultModel = (ListModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }
        [Test]
        public async Task WhenListItemHelperCalled_ThenCorrectClassCalled()
        {
            var tagHelper = Substitute.For<IMockViewComponentHelper>();

            var componentTag = new ListItemTagHelper(tagHelper)
            {
                Text = "Test"
            };
            string text = componentTag.Text;

            await ViewComponentTestHelper.CallTagHelper("ListItem", tagHelper, componentTag);
        }
        
        [TestCase(nameof(ListItemModel.Text), "The Text Field has Been Set")]
        public void WhenListItemInvoked_TheViewModelIsUpdated(string key, string value)
        {
            var values = new Dictionary<string, string>() { { key, value } };

            var component = new ListItem();
            component.ViewComponentContext = ViewComponentTestHelper.GetViewComponentContext();

            ViewViewComponentResult result = component.Invoke(values) as ViewViewComponentResult;
            ListItemModel resultModel = (ListItemModel)result.ViewData.Model;

            //Assert
            value.Should().Be(ViewComponentTestHelper.GetPropertyValue(resultModel, key));
        }
    }

}
