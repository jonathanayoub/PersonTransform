using AutoFixture.NUnit3;
using PersonTransform.Tests.Common.AutoFixture.Fixtures;

namespace PersonTransform.Tests.Common.AutoFixture.Attributes
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(new AutoMoqDataFixture())
        { }
    }
}
