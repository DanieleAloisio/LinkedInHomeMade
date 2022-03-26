using Data_Models;
using System;
using System.Collections.Generic;

namespace LinkedInHomeMade.Models
{
    public class ApplicationUserModel
    {
        public string IdProfilo { get; set; }

        public string Nome { get; set; }

        public string NickName { get; set; }

        public string Cognome { get; set; }

        public string Informazioni { get; set; }

        public string Paese { get; set; }

        public string Citta { get; set; }

        public string Mobile { get; set; }

        public string Website { get; set; }

        public string Instagram { get; set; }

        public string Github { get; set; }

        public string Facebook { get; set; }

        public string ImageProfile { get; set; }

        public string Email { get; set; }

        public string Professione { get; set; }

        public ICollection<Skills> Skills { get; set; } = new List<Skills>();
        public ICollection<Fans> Fans { get; set; } = new List<Fans>();
        public CurriculumVitae CurriculumVitae { get; set; } = new CurriculumVitae();
        public TipoGruppo TipoGruppo { get; set; } = new TipoGruppo();


        public ApplicationUserModel(ApplicationUser dbUser)
        {
            IdProfilo = dbUser.Id;
            Nome = dbUser.Nome;
            Cognome = dbUser.Cognome;
            Informazioni = dbUser.Informazioni;
            Citta = dbUser.Citta;
            Paese = dbUser.Paese;
            Professione = dbUser.Professione;
            Email = dbUser.Email;
            Mobile = dbUser.PhoneNumber;
            NickName = dbUser.UserName;
            Website = dbUser.Website;
            Instagram = dbUser.Instagram;
            Facebook = dbUser.Facebook;
            ImageProfile = dbUser.ImageProfile;
            Github = dbUser.Github;
            Skills = dbUser.Skills;
            Fans = dbUser.Fan;
            
            CurriculumVitae = dbUser.CurriculumVitae;
            TipoGruppo = dbUser.TipoGruppo;
        }
    }
}
