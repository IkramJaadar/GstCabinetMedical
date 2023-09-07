using GstCabinetMedical.Models;
using GstCabinetMedicals;
using Microsoft.AspNetCore.Mvc;

namespace GstCabinetMedical.Controllers
{
	public class PatientController : Controller
	{
		public ApplicationContext db;
		public PatientController(ApplicationContext db)
		{
			this.db = db;
		}
		public IActionResult List()
		{
            int? medid = HttpContext.Session.GetInt32("Id");
            var lst = db.Patients.Join(db.RendezVous, p => p.Id, r => r.PatientID, (p, r) => new { p, r })
				.Where(x => x.r.MedcinID == medid)
				.Select(x => x.p)
				.ToList();

            return View(lst);
		}
	}
}
