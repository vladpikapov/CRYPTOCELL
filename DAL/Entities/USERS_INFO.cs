using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DAL.Entities
{
    

    public partial class USERS_INFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERS_INFO()
        {
            CURREINCIES = new HashSet<CURREINCIES>();
        }

        public int? UserID { get; set; }

        [Key]
        [StringLength(50)]
        public string UserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CURREINCIES> CURREINCIES { get; set; }

        public virtual USERS_LOG USERS_LOG { get; set; }
    }
}
