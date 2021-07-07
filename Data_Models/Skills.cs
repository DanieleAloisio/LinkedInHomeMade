using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data_Models
{
    public class Skills
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Descrizione { get; set; }

        [StringLength(20)]
        public string Tag { get; set; }

        public int Competenza { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
