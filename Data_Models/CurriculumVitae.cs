using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Models
{
    public class CurriculumVitae
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string ContentType { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string File { get; set; }

        [ForeignKey("IdApplicationUser")]
        public Guid IdApplicationUser { get; set; }
    }
}
