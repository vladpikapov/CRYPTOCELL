namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USERS_TRANSACTIONS
    {
        [Key]
        public int TransID { get; set; }

        [Required]
        [StringLength(50)]
        public string FromUserName { get; set; }

        [Required]
        [StringLength(50)]
        public string ToUserName { get; set; }

        [Required]
        [StringLength(100)]
        public string SumOfTans { get; set; }

        public DateTime DateOfTrans { get; set; }

        public int UserID { get; set; }
    }
}
