using GstCabinetMedical;
using GstCabinetMedical.Models;
using Microsoft.EntityFrameworkCore;

namespace GstCabinetMedicals
{
    public class ApplicationContext:DbContext
    {
       
            public ApplicationContext()
            {
            }

            public ApplicationContext(DbContextOptions options) : base(options)
            { }
        public DbSet<Medcin> Medcins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<RendezVous> RendezVous { get; set; }
        public DbSet<Disponibilite> Disponibilites { get; set; }

    }
}
