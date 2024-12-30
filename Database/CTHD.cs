namespace OrderMillTeaProgram.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [StringLength(50)]
        public string IdCTHD { get; set; }

        [StringLength(50)]
        public string IdHoaDon { get; set; }

        [StringLength(50)]
        public string IdDrink { get; set; }

        public int? SoLuong { get; set; }

        public virtual Drink Drink { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
