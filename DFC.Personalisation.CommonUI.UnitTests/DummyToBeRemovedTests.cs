using FluentAssertions;
using NUnit.Framework;

namespace DFC.Personalisation.CommonUI.UnitTests
{
    [TestFixture]
    public class DummyToBeRemovedTests
    {
        [Test]
        public void tdd()
        {
            var sut = new DummyToBeRemoved();

            sut.RemoveMe();

            sut.Should().NotBeNull();
        }
    }
}
