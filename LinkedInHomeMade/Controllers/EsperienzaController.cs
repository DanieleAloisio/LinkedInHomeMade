using Data;
using LinkedInHomeMade.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInHomeMade.Controllers
{
    public class EsperienzaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EsperienzaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var exp = _context.Esperienze.Where(x => x.IdProfilo == 1).Select(x => new EsperienzaModel
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
                IdProfilo = x.IdProfilo
            });

            return View(exp);
        }
    }
}
