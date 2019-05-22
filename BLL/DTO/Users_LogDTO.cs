using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
   public class Users_LogDTO
    {
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
    }
}
