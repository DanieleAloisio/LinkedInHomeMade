using System;
using System.Collections.Generic;

namespace LinkedInHomeMade.Models
{
    public class ProfiloModel
    {
        public string IdProfilo { get; set; }

        public string Nome { get; set; }

        public string NickName { get; set; }

        public string Cognome { get; set; }

        public string Informazioni { get; set; }

        public string Paese { get; set; }

        public string Citta { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Professione { get; set; }

        public ICollection<EsperienzaModel> Esperienze { get; set; }

    }
}
