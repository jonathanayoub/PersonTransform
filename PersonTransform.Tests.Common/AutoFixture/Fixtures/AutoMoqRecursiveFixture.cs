using AutoFixture;
using AutoFixture.AutoMoq;
using PersonTransform.Tests.Common.AutoFixture.Customizations;

namespace PersonTransform.Tests.Common.AutoFixture.Fixtures
{
    public class AutoMoqRecursiveFixture : Fixture
    {
        public AutoMoqRecursiveFixture()
        {
            this.Customize(new AutoMoqCustomization());
            this.Customize(new RecursionBehaviorCustomization());
        }
    }
}
