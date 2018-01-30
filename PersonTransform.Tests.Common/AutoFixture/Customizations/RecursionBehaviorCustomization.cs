using AutoFixture;

namespace PersonTransform.Tests.Common.AutoFixture.Customizations
{
    public class RecursionBehaviorCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
