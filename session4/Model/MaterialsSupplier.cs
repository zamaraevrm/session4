#nullable disable

namespace session4.Model
{
    public partial class MaterialsSupplier
    {
        public string Material { get; set; }
        public string Supplier { get; set; }

        public virtual Material MaterialNavigation { get; set; }
        public virtual Supplier SupplierNavigation { get; set; }
    }
}
