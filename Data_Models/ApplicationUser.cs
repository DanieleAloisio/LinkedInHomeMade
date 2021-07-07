using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string Nome { get; set; }

        [Required]
        [StringLength(20)]
        public string Cognome { get; set; }

        [Required]
        [StringLength(20)]
        public string Paese { get; set; }

        [Required]
        [StringLength(20)]
        public string Citta { get; set; }

        [Required]
        [StringLength(20)]
        public string Professione { get; set; }

        [StringLength(250)]
        public string Informazioni { get; set; }


        [StringLength(20)]
        public string Website { get; set; }
        
        [StringLength(20)]
        public string Instagram { get; set; }
       
        [StringLength(20)]
        public string Github { get; set; }
        
        [StringLength(20)]
        public string Facebook { get; set; }
        
        [StringLength(20)]
        public string Twitter { get; set; }
        public int IdTipoGruppo { get; set; }
        [ForeignKey("IdTipoGruppo")]
        public TipoGruppo TipoGruppo { get; set; }
        public ICollection<Esperienza> Esperienze { get; set; }

        public ICollection<Skills> Skills { get; set; }
    }
}
