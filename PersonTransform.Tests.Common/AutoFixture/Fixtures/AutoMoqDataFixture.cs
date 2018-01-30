using AutoFixture;
using AutoFixture.AutoMoq;

namespace PersonTransform.Tests.Common.AutoFixture.Fixtures
{
    public class AutoMoqDataFixture : Fixture
    {
        public AutoMoqDataFixture()
        {
            this.Customize(new AutoMoqCustomization());
        }
    }
}
