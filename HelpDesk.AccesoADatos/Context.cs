using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HelpDesk.AccesoADatos
{
    public class Context:DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Casos>().ToTable("Casos");
        }

        public DbSet<Model.Casos> Casos { get; set; }

    }
}
