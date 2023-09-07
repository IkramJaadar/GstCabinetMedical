using GstCabinetMedical.Models;
using GstCabinetMedicals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace GstCabinetMedical.Controllers
{
    public class AutheMedController : Controller
    {
        public ApplicationContext db;
        public AutheMedController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Medcin medcin)
        {
            var lg = db.Medcins.FirstOrDefault(m => m.Email.Equals(medcin.Email) && m.Password.Equals(medcin.Password));
            if (lg != null)
            {
                HttpContext.Session.SetInt32("Id", lg.Id) ;
                HttpContext.Session.SetString("fullname", lg.Nom + " " + lg.Prenom);
                HttpContext.Session.SetString("email", lg.Email);
                return RedirectToAction("Index","Home");
            }
            return View(medcin);
        }

    }
}