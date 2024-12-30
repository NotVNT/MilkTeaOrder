namespace OrderMillTeaProgram.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Drink")]
    public partial class Drink
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drink()
        {
            CTHD = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(50)]
        public string IdDrink { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        [StringLength(50)]
        public string idLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHD { get; set; }

        public virtual Loai Loai { get; set; }
    }
}
