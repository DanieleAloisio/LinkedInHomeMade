using DAL;
using Data;
using Data_Models;
using LinkedInHomeMade.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace LinkedInHomeMade.Controllers
{
    [Authorize] //Test EMAIL
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

        [HttpGet]
        public async Task<IActionResult> Contatti()
        {
            var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);
            var dbProfilo = _unitOfWork.UserRepository.GetUserById(userLogged.Id);

            var profiloModel = new ApplicationUserModel(dbProfilo);

            return View(profiloModel);
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

            try
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
            catch (System.Exception)
            {
                return Json(new { status = false });
            }


        }

        [HttpPost]
        public async Task<JsonResult> AggiungiSkill(string tag)
        {
            try
            {
                var splittedTag = tag.Split(',');

                if (splittedTag.Any())
                {
                    var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);

                    splittedTag.ToList().ForEach(item =>

                    userLogged.Skills.Add(new Skills()
                    {
                        Tag = item,
                        Competenza = 10
                    }));

                    await _unitOfWork.SaveChangesAsync();
                }

                return Json(new { status = true });
            }
            catch (System.Exception ex)
            {

                return Json(new object());
            }

        }

        [HttpPost]
        public async Task<JsonResult> ModificaCompetenzaSkill(string idTag, string valCompetenza)
        {
            var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);
            var dbProfilo = _unitOfWork.UserRepository.GetUserById(userLogged.Id);

            var skill = dbProfilo.Skills.FirstOrDefault(x => x.Id == int.Parse(idTag));

            if (skill != null)
            {
                skill.Competenza = int.Parse(valCompetenza);
            }

            await _unitOfWork.SaveChangesAsync();
            return Json(new { status = true });
        }

        [HttpPost]
        public async Task<JsonResult> EliminaCompetenzaSkill(string idTag)
        {
            var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);
            var dbProfilo = _unitOfWork.UserRepository.GetUserById(userLogged.Id);

            var skill = dbProfilo.Skills.FirstOrDefault(x => x.Id == int.Parse(idTag));

            await _unitOfWork.Remove(skill);
            return Json(new { status = true });
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);
                    var fileBase64 = "";
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        fileBase64 = Convert.ToBase64String(fileBytes);
                    }

                    if (fileBase64 != null)
                    {
                        userLogged.CurriculumVitae =
                            new CurriculumVitae()
                            {
                                File = fileBase64,
                                ContentType = file.ContentType,
                                Name = file.FileName,
                                UserId = Guid.Parse(userLogged.Id)
                            };
                    }

                    await _unitOfWork.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DownloadFile(IFormFile file)
        {
            try
            {

                var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);
                var dbProfilo = _unitOfWork.UserRepository.GetUserById(userLogged.Id);

                byte[] bytes = Convert.FromBase64String(dbProfilo.CurriculumVitae.File);

                return File(bytes, dbProfilo.CurriculumVitae.ContentType, Path.GetFileName(dbProfilo.CurriculumVitae.Name));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
