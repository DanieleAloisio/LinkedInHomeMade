using Data;
using Data_Models;
using LinkedInHomeMade.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<ApplicationUser> _signInManager;

        public EsperienzaController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);

            var exp = _context.Esperienze.Where(x => x.IdApplicationUser == userLogged.Id).Select(x => new EsperienzaModel
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
                IdProfilo = x.IdApplicationUser,
                IdTipoEsperienza = x.IdTipoEsperienza
            });

            return View(exp);
        }

        public async Task<IActionResult> Education()
        {
            var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);
            //TODO: da sistemare
            var exp = _context.Esperienze.Where(x => x.IdApplicationUser == userLogged.Id).Select(x => new EsperienzaModel
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
                IdProfilo = x.IdApplicationUser,
                IdTipoEsperienza = x.IdTipoEsperienza,
                Votazione = x.Votazione.HasValue ? x.Votazione.Value.ToString() : "-"
               
            });

            return View(exp);
        }
    }
}
