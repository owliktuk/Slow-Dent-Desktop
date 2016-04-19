using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Slow_Dent_Desktop
{
    //klasa kontekstowa do EntityFramework
    public class DatabaseContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Tooth> Teeth { get; set; }
    }
}
