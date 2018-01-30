using AutoFixture;
using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using PersonTransform.Core;
using PersonTransform.Data.Entities;
using PersonTransform.Tests.Common.AutoFixture.Assertions;
using PersonTransform.Tests.Common.AutoFixture.Attributes;

namespace PersonTransform.Tests.PersonTransform.Core
{
    [TestFixture]
    public class Given_the_attempt_to_use_MappingExportPersonListFactory_incorrectly
    {
        [Test]
        [AutoMoqData]
        public void When_creating_with_null_dependencies_then_an_exception_is_thrown(Fixture fixture)
        {
            var assertion = new ConstructorGuardClauseAssertion<MappingExportPersonListFactory>(fixture);
            assertion.Verify();
        }
    }



    [TestFixture]
    public class Given_a_list_of_import_persons_with_data_to_create_export_persons
    {
        [Test]
        [AutoData]
        public void When_the_export_persons_are_created_then_they_are_created_correctly(
            IEnumerable<ImportPerson> dummyImportPersons,
            ExportPerson dummyExportPerson)
        {
            var stubPersonFactory = new Mock<ExportPersonFactory>();
            //On any Create call with ImportPerson export the same dummyExportPerson
            stubPersonFactory
                .Setup(f => f.Create(It.IsAny<ImportPerson>()))
                .Returns(dummyExportPerson);
            var fixture = new Fixture();
            fixture.Inject(stubPersonFactory.Object);
            var sut = fixture.Create<MappingExportPersonListFactory>();

            var result = sut.Create(dummyImportPersons);

            Assert.That(result.Any());
            //Assert all export persons in result refer to dummyExportPerson instance
            Assert.That(result.All(p => p.Equals(dummyExportPerson)));
        }
    }

    [TestFixture]
    public class Given_an_import_person_with_data_to_create_an_export_person
    {
        [Test]
        [AutoData]
        public void When_the_exported_person_is_created_then_the_address_is_copied(
            string dummyAddress,
            ExportPersonFactory sut)
        {
            var importPerson = new ImportPerson { Address = dummyAddress };

            var result = sut.Create(importPerson);

            Assert.AreEqual(dummyAddress, result.Address);
        }

        [Test]
        [AutoData]
        public void When_the_imported_person_has_a_gender_of_M_then_the_exported_person_name_is_prepended_with_Mr(
            ExportPersonFactory sut)
        {
            var importPerson = new ImportPerson { Gender = Gender.M, Name = "Brian" };

            var result = sut.Create(importPerson);

            Assert.AreEqual("Mr. Brian", result.Name);
        }

        [Test]
        [AutoData]
        public void When_the_imported_person_has_a_gender_of_F_then_the_exported_person_name_is_prepended_with_Mrs(
            ExportPersonFactory sut)
        {
            var importPerson = new ImportPerson { Gender = Gender.F, Name = "Briana" };

            var result = sut.Create(importPerson);

            Assert.AreEqual("Ms. Briana", result.Name);
        }

        [Test]
        [AutoData]
        public void When_the_imported_person_favorite_color_is_blue_red_or_orange_then_the_exported_person_iscool_is_false(
            ExportPersonFactory sut)
        {
            ImportPerson importPerson = SetupUncoolPerson();

            var result = sut.Create(importPerson);

            Assert.IsFalse(result.IsCool);
        }

        [Test]
        [AutoData]
        public void When_the_imported_person_favorite_color_is_purple_pink_or_green_then_the_exported_person_iscool_is_true(
            ExportPersonFactory sut)
        {
            ImportPerson importPerson = SetupCoolPerson();

            var result = sut.Create(importPerson);

            Assert.IsTrue(result.IsCool);
        }

        [Test]
        [AutoData]
        public void When_the_exported_person_iscool_property_is_true_then_the_acquisitiondate_is_2_years_after_imported_person_observation_date(
            ExportPersonFactory sut)
        {
            ImportPerson importPerson = SetupCoolPerson();
            importPerson.ObservationDate = DateTime.Now;

            var result = sut.Create(importPerson);

            Assert.IsTrue(result.AcquisitionDate != null);
            Assert.AreEqual(importPerson.ObservationDate.AddYears(2), result.AcquisitionDate);
        }

        [Test]
        [AutoData]
        public void When_the_exported_person_iscool_property_is_false_then_the_acquisitiondate_is_null(
            ExportPersonFactory sut)
        {
            ImportPerson importPerson = SetupUncoolPerson();

            var result = sut.Create(importPerson);

            Assert.IsNull(result.AcquisitionDate);
        }

        private static ImportPerson SetupCoolPerson()
        {
            var coolColors = new[] { Color.Purple, Color.Pink, Color.Green };
            var randomCoolColor = coolColors[new Random().Next(3)];
            var importPerson = new ImportPerson { FavoriteColor = randomCoolColor };
            return importPerson;
        }

        private static ImportPerson SetupUncoolPerson()
        {
            var unCoolColors = new[] { Color.Blue, Color.Orange, Color.Red };
            var randomCoolColor = unCoolColors[new Random().Next(3)];
            var importPerson = new ImportPerson { FavoriteColor = randomCoolColor };
            return importPerson;
        }
    }
}
