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
    public class Given_the_attempt_to_use_JsonImportPersonRepo_incorrectly
    {
        [Test]
        [AutoMoqData]
        public void When_creating_with_null_dependencies_then_an_exception_is_thrown(Fixture fixture)
        {
            var assertion = new ConstructorGuardClauseAssertion<JsonImportPersonRepo>(fixture);
            assertion.Verify();
        }
    }

    [TestFixture]
    public class Given_a_list_of_import_persons_in_the_repo
    {
        [Test]
        [AutoMoqData]
        public void When_the_list_is_retrieved_then_it_is_retrieved_from_the_json_file(
            [Frozen] Mock<IConfig> stubConfig,
            [Frozen] Mock<IJson> stubJson,
            string dummyImportPath,
            IList<ImportPerson> dummyRepoPersons,
            JsonImportPersonRepo sut)
        {
            stubConfig.Setup(c => c.ImportPath).Returns(dummyImportPath);
            stubJson
                .Setup(j =>
                    j.ReadFile<IList<ImportPerson>>(dummyImportPath))
                .Returns(dummyRepoPersons);

            var result = sut.GetAll();

            Assert.AreSame(dummyRepoPersons, result);
        }
    }
}
