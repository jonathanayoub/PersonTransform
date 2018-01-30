using PersonTransform.Data.Entities;

namespace PersonTransform.Core
{
    public class ExportPersonFactory
    {
        private const string MaleSalutation = "Mr. ";
        private const string FemaleSalutation = "Ms. ";

        public virtual ExportPerson Create(ImportPerson importPerson)
        {
            var returnPerson = new ExportPerson();

            RunTransforms(importPerson, returnPerson);
            returnPerson.Address = importPerson.Address;

            return returnPerson;
        }

        private static void RunTransforms(ImportPerson importPerson, ExportPerson returnPerson)
        {
            RunSalutationTransform(importPerson, returnPerson);
            RunIsCoolTransform(importPerson, returnPerson);
            RunAcquisitionDateTransform(importPerson, returnPerson);
        }

        private static void RunSalutationTransform(ImportPerson importPerson, ExportPerson returnPerson)
        {
            switch (importPerson.Gender)
            {
                case Gender.M:
                    returnPerson.Name = MaleSalutation + importPerson.Name;
                    break;
                case Gender.F:
                    returnPerson.Name = FemaleSalutation + importPerson.Name;
                    break;
            }
        }

        private static void RunIsCoolTransform(ImportPerson importPerson, ExportPerson returnPerson)
        {
            returnPerson.IsCool =
                importPerson.FavoriteColor == Color.Purple
                || importPerson.FavoriteColor == Color.Pink
                || importPerson.FavoriteColor == Color.Green;
        }

        private static void RunAcquisitionDateTransform(ImportPerson importPerson, ExportPerson returnPerson)
        {
            if (returnPerson.IsCool)
                returnPerson.AcquisitionDate = importPerson.ObservationDate.AddYears(2);
            else
                returnPerson.AcquisitionDate = null;
        }
    }
}