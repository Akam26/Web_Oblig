using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
//using System.Web.Mvc;
//using System.Web.SessionState;
using System.Net.Http;
using Models;


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
            public DbSet<Varekategori> Varekategorier { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }

            //internal void SaveChanges()
            //{
            //    throw new NotImplementedException();
            //}
        }
    }
}
