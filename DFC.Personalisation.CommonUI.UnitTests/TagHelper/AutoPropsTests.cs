using DFC.Personalisation.CommonUI.TagHelpers;
using DFC.Personalisation.CommonUI.ViewComponents.Components.AutoComplete;
using DFC.Personalisation.CommonUI.ViewComponents.Components.Button;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace DFC.Personalisation.CommonUI.UnitTests.TagHelper
{
    public class AutoPropsTests
    {

        [Test]
        public void When_AutoPropReceivedTheWrongTypeForAProperty_ThenErrorIsThrown()
        {
            var model = new AutoCompleteModel();
            var values = new Dictionary<string, string>
            {
                {nameof(AutoCompleteModel.MinLength), "lll"}
            };


            model.Invoking(m => m.SetProps(values)).Should().Throw<AutoPropException>()
                .WithMessage("Unable to Map property");

        }

        [Test]
        public void When_AutoPropReceivesAPropertyWithHyphen_Then_PropertyIsMappedToTheCorrectVariable()
        {
            const string additionalClass = "lll";
            var model = new ButtonModel();

            var values = new Dictionary<string, string>
            {
                { "additional-class", additionalClass }
            };

            model.SetProps(values);

            model.AdditionalClass.Should().Be(additionalClass);

        }

        [Test]
        public void When_AutoPropReceivedsAPropertyWithoutAHyphen_Then_PropertyIsMappedToTheCorrectVariable()
        {
            const string text = "lll";
            var model = new ButtonModel();

            var values = new Dictionary<string, string>
            {
                { "text", text}
            };

            model.SetProps(values);

            model.Text.Should().Be(text);

        }
    }
}
