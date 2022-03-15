using System;
using System.Collections.Generic;

#nullable disable

namespace session4.Model
{
    public partial class Supplier
    {
        public Supplier()
        {
            MaterialsSuppliers = new HashSet<MaterialsSupplier>();
        }

        public string Supplier1 { get; set; }
        public string TypeSupplier { get; set; }
        public string Inn { get; set; }
        public long? RatingOfQuality { get; set; }
        public byte[] StartDateOfWorkWithTheSupplier { get; set; }

        public virtual ICollection<MaterialsSupplier> MaterialsSuppliers { get; set; }
    }
}
