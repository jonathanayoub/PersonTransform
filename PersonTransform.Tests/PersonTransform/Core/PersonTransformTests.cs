using Moq;
using NUnit.Framework;
using PersonTransform.Data.Entities;
using PersonTransform.Data.Interfaces;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.NUnit3;
using PersonTransform.Tests.Common.AutoFixture.Assertions;
using PersonTransform.Tests.Common.AutoFixture.Attributes;
using Transform = PersonTransform.Core;

namespace PersonTransform.Tests.PersonTransform.Core
{
    [TestFixture]
    public class Given_the_attempt_to_use_PersonTransform_incorrectly
    {
        [Test]
        [AutoMoqData]
        public void When_creating_with_null_dependencies_then_an_exception_is_thrown(Fixture fixture)
        {
            var assertion = new ConstructorGuardClauseAssertion<Transform.PersonTransform>(fixture);
            assertion.Verify();
        }
    }

    [TestFixture]
    public class Given_a_list_of_import_persons_to_transform
    {
        [Test]
        [AutoMoqData]
        public void When_the_persons_are_transformed_then_they_are_added_to_the_export(
            [Frozen] Mock<IImportPersonRepo> stubImportPersonRepo,
            [Frozen] Mock<Transform.IExportPersonListFactory> stubExportPersonFactory,
            [Frozen] Mock<IExportPersonRepo> mockExportPersonRepo,
            IList<ImportPerson> dummyImportPersons,
            IList<ExportPerson> transformedExportPersons,
            Transform.PersonTransform sut)
        {
            stubImportPersonRepo
                .Setup(r => r.GetAll())
                .Returns(dummyImportPersons);
            stubExportPersonFactory
                .Setup(f => f.Create(dummyImportPersons))
                .Returns(transformedExportPersons);

            sut.Run();

            mockExportPersonRepo
                .Verify(r => r.Add(transformedExportPersons), Times.Once());
        }
    }
}
