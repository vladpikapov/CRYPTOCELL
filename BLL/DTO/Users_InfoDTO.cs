using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
   public class Users_InfoDTO
    {
        public int? UserID { get; set; }

        [Key]
        [StringLength(50)]
        public string UserName { get; set; }
    }
}
