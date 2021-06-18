﻿using Data;
using Data_Models;
using LinkedInHomeMade.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinkedInHomeMade.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var prof = _context.Profili.Select(x => new ProfiloModel
            {
                IdProfilo = x.IdProfilo,
                Nome = x.Nome,
                Cognome = x.Cognome,
                Informazioni = x.Informazioni,
                Citta = x.Citta,
                Paese = x.Paese,
                Professione = x.Professione,
                Email = x.Email,
                Mobile = x.Mobile,
                NickName = x.NickName
                
            }).FirstOrDefault();

            return View(prof);
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
    }
}
