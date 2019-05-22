using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTO
{
    public class CurreinciesDTO
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
    }
}
