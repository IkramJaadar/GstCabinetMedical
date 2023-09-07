using GstCabinetMedicals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace GstCabinetMedical.Controllers
{
	public class RdVousController : Controller
	{
		public ApplicationContext db;
		public RdVousController(ApplicationContext db)
		{
			this.db = db;
		}
		public IActionResult List()
		{
			List<RendezVous> lists = db.RendezVous.Include(c => c.Patient).Include(t => t.Medcin).ToList();
			foreach (var rendezVous in lists)
			{
				// Access patient's information
				//int patientNumber = rendezVous.Patient.Id;
				string patientTelephone = rendezVous.Patient.Telephone;

				// Access doctor's information
				string doctorName = rendezVous.Medcin.Nom;
			}
			return View(lists);
		}
	}
}
	

	


	


