using System;

namespace PersonTransform.Data.Entities
{
    public class ExportPerson
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public bool IsCool { get; set; }
    }
}
