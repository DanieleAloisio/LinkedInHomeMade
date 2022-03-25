using DAL;
using Data;
using Data_Models;
using LinkedInHomeMade.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Explore()
        {
            try
            {
                var userLogged = await _signInManager.UserManager.GetUserAsync(this.User);

                var listUsers = _unitOfWork.UserRepository.GetUsers();
                var users = new List<ApplicationUserModel>();

                foreach (var user in listUsers)
                {
                    if (user.Id != userLogged.Id.ToString())
                    {
                        users.Add(new ApplicationUserModel(user));
                    }
                }

                return View(users);

            }
            catch (System.Exception e)
            {

                throw;
            }
        }

        public IActionResult ViewProfile(string idProfilo)
        {
            try
            {
                var user = new ApplicationUserModel(_unitOfWork.UserRepository.GetUserById(idProfilo));

                return View(user);

            }
            catch (System.Exception e)
            {
                throw;
            }
        }
    }
}
