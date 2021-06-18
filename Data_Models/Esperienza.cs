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

        //Foreign key for Standard
        [ForeignKey("IdProfilo")]
        public Profilo Profilo { get; set; }

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

        public ICollection<TipoEsperienza> TipoEsperienze { get; set; }


    }
}

