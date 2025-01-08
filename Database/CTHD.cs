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
        [Column(Order = 0)]
        [StringLength(50)]
        public string IdHoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string IdDrink { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(10)]
        public string price { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string KhuyenMai { get; set; }
    }
}
