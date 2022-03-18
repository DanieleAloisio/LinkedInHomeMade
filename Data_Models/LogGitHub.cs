using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data_Models
{
    public class LogGitHub
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(150)]
        public string Message { get; set; }

        [StringLength(100)]
        public string ApplicationName { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

    }
}
