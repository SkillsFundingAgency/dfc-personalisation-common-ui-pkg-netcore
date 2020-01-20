using DFC.Personalisation.CommonUI.TagHelpers;
using DFC.Personalisation.CommonUI.ViewComponents.Components.AutoComplete;
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
    }
}
