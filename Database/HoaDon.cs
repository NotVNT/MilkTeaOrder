namespace OrderMillTeaProgram
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        [StringLength(50)]
        public string idHoaDon { get; set; }

        public DateTime? NgayinHoaDon { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }
    }
}
