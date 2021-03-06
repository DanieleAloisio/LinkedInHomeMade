using DAL;
using Data;
using Data_Models;
using LinkedInHomeMade.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace LinkedInHomeMade.Controllers
{
    [Authorize] //TEST SQL AZURE
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
        public async Task<JsonResult> ModificaProfilo(string nome, string cognome, string professione, string mobile)
        {

            try
            {
                var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);

                if (userLogged != null)
                {
                    userLogged.Nome = nome;
                    userLogged.Cognome = cognome;
                    userLogged.Professione = professione;
                    userLogged.PhoneNumber = mobile;
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
                    return AjaxResponse.DoneJsonResult("Nuova skill salvata");

                }

                return Json(new { status = true });
            }
            catch (System.Exception e)
            {
                _unitOfWork.LogRepository.SaveLog(e.Message, LogMessageType.Error, "AggiungiSkill");
                return AjaxResponse.ErrorJsonResult("Si è verificato un problema. Riprovare.");
            }

        }

        [HttpGet]
        public async Task<JsonResult> GetSkills()
        {
            try
            {
                var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);
                var dbProfilo = _unitOfWork.UserRepository.GetUserById(userLogged.Id);

                var skills = dbProfilo.Skills.ToList();
                List<SkillResponse> response = new List<SkillResponse>();
                
                if (skills.Any())
                {

                    skills.ForEach(skill => response.Add(new SkillResponse() { Id = skill.Id.ToString(), Tag = skill.Tag }));
                }

                return Json(response);
            }
            catch (Exception e)
            {

                _unitOfWork.LogRepository.SaveLog(e.Message, LogMessageType.Error, "AggiungiSkill");
                return AjaxResponse.ErrorJsonResult("Si è verificato un problema. Riprovare.");
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

        [HttpPost]
        public async Task<IActionResult> EliminaFile()
        {
            var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);
            var dbProfilo = _unitOfWork.UserRepository.GetUserById(userLogged.Id);

            var cv = dbProfilo.CurriculumVitae;

            await _unitOfWork.Remove(cv);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> UploadImage(string file)
        {
            try
            {
                if (file != null)
                {
                    var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);

                    userLogged.ImageProfile = file;

                    await _unitOfWork.SaveChangesAsync();
                }

                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
