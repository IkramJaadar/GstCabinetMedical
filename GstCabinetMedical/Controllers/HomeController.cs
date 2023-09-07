using GstCabinetMedical.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GstCabinetMedical.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
		public async Task<IActionResult> Logout()
		{
			// Déconnecter l'utilisateur et supprimer ses informations d'authentification de la session.
			await HttpContext.SignOutAsync();
			// Rediriger vers la page d'accueil ou une autre page après la déconnexion.
			return RedirectToAction("Login", "AutheMed");
		}
	}
}
