namespace OrderMillTeaProgram
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Drink")]
    public partial class Drink
    {
        [Key]
        [StringLength(50)]
        public string IdDrink { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        [StringLength(50)]
        public string idLoai { get; set; }

        public virtual Loai Loai { get; set; }
    }
}
