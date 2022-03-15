using System;
using System.Collections.Generic;

#nullable disable

namespace session4.Model
{
    public partial class Material
    {
        public Material()
        {
            MaterialsSuppliers = new HashSet<MaterialsSupplier>();
        }

        public string NameMaterial { get; set; }
        public string TypeMaterial { get; set; }
        public string UrlImage { get; set; }
        public byte[] Price { get; set; }
        public long? Quantity { get; set; }
        public long? MinQuantity { get; set; }
        public long? QuantityInThePackeg { get; set; }
        public string UnitOfMeasurement { get; set; }

        public virtual ICollection<MaterialsSupplier> MaterialsSuppliers { get; set; }
    }
}
