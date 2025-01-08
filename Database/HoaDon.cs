namespace OrderMillTeaProgram.Database
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

        public DateTime? DateCheckIn { get; set; }

        public DateTime? DateCheckOut { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }
    }
}
