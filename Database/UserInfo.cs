
namespace OrderMillTeaProgram.Database

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        [Key]
        [StringLength(50)]
        public string UserName { get; set; }


        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]

        public string SDT { get; set; }

        [Required]
        [StringLength(50)]

        public string Role { get; set; }
    }
}
