using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInHomeMade.Models
{
    public class SkillViewModel
    {

        public int Id { get; set; }

        public int IdApplicationUser { get; set; }

        public string Descrizione { get; set; }

        public string Tag { get; set; }

        public int Competenza { get; set; }
    }
}
