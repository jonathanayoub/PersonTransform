using System;

namespace PersonTransform.Data.Entities
{
    public class ImportPerson
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime ObservationDate { get; set; }
        public Gender Gender { get; set; }
        public Color FavoriteColor { get; set; }
    }
}
