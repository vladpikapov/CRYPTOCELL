namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USERS_LOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERS_LOG()
        {
            USERS_INFO = new HashSet<USERS_INFO>();
        }

        [Key]
        public int UserLogID { get; set; }

        [Required]
        [StringLength(70)]
        public string UserLogName { get; set; }

        [Required]
        [StringLength(200)]
        public string UserLogPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string UserMail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERS_INFO> USERS_INFO { get; set; }
    }
}
