using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Slow_Dent_Desktop
{

    public class PatientsDatabaseContext : DbContext
    {
        public DbSet<Patient> Pacjenci { get; set; }
        public DbSet<Tooth> Teeth { get; set; }
        public DbSet<TreatmentHistory> previousTreatments { get; set; }
        public DbSet<TreatmentPlans> nextTreatments { get; set; }
        public DbSet<Disease> Diseases { get; set; }

        public PatientsDatabaseContext(string connectionString): base(connectionString) 
        {
            Database.SetInitializer(new SlowDentDBInitializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Patient>()
                        .HasMany<Disease>(s => s.itsDiseases).WithMany();

        }
    }

    public class SlowDentDBInitializer : DropCreateDatabaseIfModelChanges<PatientsDatabaseContext>
    {

        protected override void Seed(PatientsDatabaseContext context)
        {
            IList<Disease> defaultDiseases = new List<Disease>();

            defaultDiseases.Add(new Disease("Niewydolność krążenia"));
            defaultDiseases.Add(new Disease("Wada serca"));
            defaultDiseases.Add(new Disease("Nerwica"));
            defaultDiseases.Add(new Disease("Nadciśnienie"));
            defaultDiseases.Add(new Disease("Cukrzyca"));
            defaultDiseases.Add(new Disease("Choroby tarczycy"));
            defaultDiseases.Add(new Disease("Jaskra"));
            defaultDiseases.Add(new Disease("Zawał"));
            defaultDiseases.Add(new Disease("Zastawki/rozrusznik"));
            defaultDiseases.Add(new Disease("Zapalenie wsierdzia"));
            defaultDiseases.Add(new Disease("Choroba wrzodowa"));
            defaultDiseases.Add(new Disease("Alergia"));
            defaultDiseases.Add(new Disease("Reumatyzm"));
            defaultDiseases.Add(new Disease("Żółtaczka"));
            defaultDiseases.Add(new Disease("Astma"));
            defaultDiseases.Add(new Disease("Hemofilia"));
            defaultDiseases.Add(new Disease("Padaczka"));
            defaultDiseases.Add(new Disease("AIDS"));


            foreach (Disease dis in defaultDiseases)
                context.Diseases.Add(dis);

            base.Seed(context);
        }
    }

}
