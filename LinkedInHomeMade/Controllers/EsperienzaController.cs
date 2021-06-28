using Data;
using Data_Models;
using LinkedInHomeMade.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInHomeMade.Controllers
{
    [Authorize]
    public class EsperienzaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EsperienzaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //TODO: da sistemare
            var exp = _context.Esperienze.Where(x => x.IdProfilo == 3).Select(x => new EsperienzaModel
            {
                Id = x.Id,
                Inizio = x.Inizio,
                Fine = x.Fine,
                Azienda = x.Azienda,
                Corso = x.Corso,
                Descrizione = x.Descrizione,
                Istituto = x.Istituto,
                Localita = x.Localita,
                Qualifica = x.Qualifica,
                TipoDiImpiego = x.TipoDiImpiego,
                TitoloStudio = x.TitoloStudio,
                IdProfilo = x.IdProfilo,
                IdTipoEsperienza = x.IdTipoEsperienza
            });

            return View(exp);
        }

        public IActionResult Education()
        {
            //TODO: da sistemare
            var exp = _context.Esperienze.Where(x => x.IdProfilo == 3).Select(x => new EsperienzaModel
            {
                Id = x.Id,
                Inizio = x.Inizio,
                Fine = x.Fine,
                Azienda = x.Azienda,
                Corso = x.Corso,
                Descrizione = x.Descrizione,
                Istituto = x.Istituto,
                Localita = x.Localita,
                Qualifica = x.Qualifica,
                TipoDiImpiego = x.TipoDiImpiego,
                TitoloStudio = x.TitoloStudio,
                IdProfilo = x.IdProfilo,
                IdTipoEsperienza = x.IdTipoEsperienza,
                Votazione = x.Votazione.HasValue ? x.Votazione.Value.ToString() : "-"
               
            });

            return View(exp);
        }
    }
}
