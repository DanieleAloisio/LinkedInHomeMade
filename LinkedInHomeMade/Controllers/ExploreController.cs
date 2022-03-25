using DAL;
using Data;
using Data_Models;
using LinkedInHomeMade.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LinkedInHomeMade.Controllers
{
    public class ExploreController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UnitOfWork _unitOfWork;

        public ExploreController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UnitOfWork unitOfWork)
        {
            _context = context;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Explore()
        {
            try
            {
                var listUsers = _unitOfWork.UserRepository.GetUsers();
                var users = new List<ApplicationUserModel>();

                foreach (var user in listUsers)
                {
                    users.Add(new ApplicationUserModel(user));
                }

                return View(users);

            }
            catch (System.Exception e)
            {

                throw;
            }
        }
    }
}
