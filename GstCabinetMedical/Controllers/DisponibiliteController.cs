using GstCabinetMedical.Models;
using GstCabinetMedicals;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace GstCabinetMedical.Controllers
{
    public class DisponibiliteController : Controller
    {
        public ApplicationContext db;
        public DisponibiliteController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            int? medecinId = HttpContext.Session.GetInt32("Id");
            List<Disponibilite> disponibilites = new List<Disponibilite>();
            if (medecinId.HasValue)
            {
                disponibilites = db.Disponibilites.Where(m => m.MedcinID == medecinId).ToList();

            }
            return View(disponibilites);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Disponibilite dispo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int? medecinId = HttpContext.Session.GetInt32("Id");
                    if (medecinId.HasValue)
                    {
                        dispo.MedcinID = medecinId.Value;
                        db.Disponibilites.Add(dispo);
                        db.SaveChanges();
                        return RedirectToAction("List");
                    }
                }
                return View(dispo);
            }
            catch (Exception ex)
            {
                // Affichez ou enregistrez l'exception pour le débogage
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("List");
            }
            var dis= db.Disponibilites.Find(id);
            if (dis != null)
            {
                db.Disponibilites.Remove(dis);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

    }
}



