using System;

namespace LinkedInHomeMade.Models
{
    public class EsperienzaModel
    {

        public int Id { get; set; }

        public int IdProfilo { get; set; }

        public DateTime Inizio { get; set; }

        public DateTime? Fine { get; set; }

        public string Descrizione { get; set; }

        public string Localita { get; set; }

        public string Istituto { get; set; }

        public string TitoloStudio { get; set; }

        public string Corso { get; set; }

        public string Qualifica { get; set; }

        public string TipoDiImpiego { get; set; }

        public string Azienda { get; set; }

    }
}
