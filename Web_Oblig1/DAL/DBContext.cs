using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using Model;

namespace DAL
{
    public class DBContext
    {
        public class Db : DbContext
        {
            public Db() : base("name=Bestilling")
            {
                Database.CreateIfNotExists();
            }

            public DbSet<Kunde> Kunder { get; set; }
            public DbSet<Vare> Varer { get; set; }
            public DbSet<Bestilling> Bestillinger { get; set; }
            public DbSet<Kategori> Varekategorier { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    }
}
