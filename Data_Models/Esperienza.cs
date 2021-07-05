using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Models
{
    public class Esperienza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Inizio { get; set; }

        public DateTime? Fine { get; set; }

        [StringLength(250)]
        public string Descrizione { get; set; }

        [StringLength(50)]
        public string Localita { get; set; }

        [StringLength(50)]
        public string Istituto { get; set; }

        [StringLength(50)]
        public string TitoloStudio { get; set; }

        [StringLength(50)]
        public string Corso { get; set; }

        [StringLength(50)]
        public string Qualifica { get; set; }

        [StringLength(50)]
        public string TipoDiImpiego { get; set; }

        [StringLength(50)]
        public string Azienda { get; set; }

        public int? Votazione { get; set; }

        public int IdProfilo { get; set; }
        //Foreign key for Standard
        [ForeignKey("IdApplicationUser")]
        public ApplicationUser ApplicationUser { get; set; }

        public int IdTipoEsperienza { get; set; }
        [ForeignKey("IdTipoEsperienza")]
        public TipoEsperienza TipoEsperienza { get; set; }


    }
}

