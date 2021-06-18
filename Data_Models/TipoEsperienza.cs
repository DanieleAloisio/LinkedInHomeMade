using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Models
{
    public class TipoEsperienza
    {
        [Key]
        public int IdTipoEsperienza { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public ICollection<Esperienza> Esperienze { get; set; }
    }
}
