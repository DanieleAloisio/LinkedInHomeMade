using DAL;
using Data;
using Data_Models;
using LinkedInHomeMade.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedInHomeMade.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UnitOfWork _unitOfWork;

        public HomeController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UnitOfWork unitOfWork)
        {
            _context = context;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);
            var dbProfilo = _unitOfWork.UserRepository.GetUserById(userLogged.Id);

            var profiloModel = new ApplicationUserModel(dbProfilo);

            return View(profiloModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<JsonResult> ModificaProfilo(string nome, string cognome, string professione, string paese, string citta, 
                                                      string informazioni, string mobile, string website, string instagram, 
                                                      string github, string facebook, string twitter)
        {
            var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);

            if (userLogged != null)
            {
                userLogged.Nome = nome;
                userLogged.Cognome = cognome;
                userLogged.Professione = professione;
                userLogged.Paese = paese;
                userLogged.Citta = citta;
                userLogged.Informazioni = informazioni;
                userLogged.PhoneNumber = mobile;
                userLogged.Website = website;
                userLogged.Instagram = instagram;
                userLogged.Github = github;
                userLogged.Facebook = facebook;
                userLogged.Twitter = twitter;
            };

            await _unitOfWork.SaveChangesAsync();
            return Json(new { status = true });
        }
    }
}
