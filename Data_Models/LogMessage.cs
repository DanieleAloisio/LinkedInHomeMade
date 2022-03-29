using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Models
{
    public class LogMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }
        
        [Required]
        public LogMessageType Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Action { get; set; }

        [Required]
        public DateTime DateMessage { get; set; }

    }

    public enum LogMessageType
    {
       Error = 0,
       Warning = 1,
       Information = 2,
       WarningInformation = 3
    }
}
