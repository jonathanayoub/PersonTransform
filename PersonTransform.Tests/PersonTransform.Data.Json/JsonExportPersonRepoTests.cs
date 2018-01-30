using Moq;
using NUnit.Framework;
using PersonTransform.Data.Entities;
using PersonTransform.Data.Json;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.NUnit3;
using PersonTransform.Tests.Common.AutoFixture.Assertions;
using PersonTransform.Tests.Common.AutoFixture.Attributes;

namespace PersonTransform.Tests.PersonTransform.Data.Json
{
    [TestFixture]
    public class Given_the_attempt_to_use_JsonExportPersonRepo_incorrectly
    {
        [Test]
        [AutoMoqData]
        public void When_creating_with_null_dependencies_then_an_exception_is_thrown(Fixture fixture)
        {
            var assertion = new ConstructorGuardClauseAssertion<JsonExportPersonRepo>(fixture);
            assertion.Verify();
        }
    }

    [TestFixture]
    public class Given_a_list_of_export_persons_to_add_to_the_repo
    {
        [Test]
        [AutoMoqData]
        public void When_the_persons_are_added_then_they_are_added_to_the_json_repo(
            [Frozen] Mock<IConfig> stubConfig,
            [Frozen] Mock<IJson> mockJsonRepo,
            string dummyPath,
            IEnumerable<ExportPerson> dummyExportPersons,
            JsonExportPersonRepo sut)
        {
            stubConfig.Setup(c => c.ExportPath).Returns(dummyPath);

            sut.Add(dummyExportPersons);

            mockJsonRepo.Verify(r => r.WriteFile(dummyPath, dummyExportPersons));
        }
    }
}
