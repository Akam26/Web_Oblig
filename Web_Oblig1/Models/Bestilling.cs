/*
* s198596 Akam Neeson
* s198518 Magnus Molaug
* s198572 Ali Mohammad
* s198574 Marius Strømme    
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Web_Oblig1.Models
{
    public class Bestilling
    {
        [Key]
        public int ordreID { get; set; }
        public virtual Kunde kundeID { get; set; }
        public virtual Vare vareID { get; set; }
        public DateTime tid { get; set; }
    }

    public class BestillingContext : DbContext
    {
        public BestillingContext()
            : base("name=Bestilling")
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