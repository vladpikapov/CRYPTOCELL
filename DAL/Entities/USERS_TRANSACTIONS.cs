using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DAL.Entities
{
    

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

        [Column(TypeName = "numeric")]
        public decimal SumOfTans { get; set; }
    }
}
