using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DAL.Entities
{

    
    public partial class CURREINCIES
    {
        
        [Key]
        public int CurID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string CurName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CurBalance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CurCourseNow { get; set; }

        [Column(TypeName = "numeric")]

        public decimal CurCourseLast { get; set; }

        public virtual USERS_INFO USERS_INFO { get; set; }
    }
}
