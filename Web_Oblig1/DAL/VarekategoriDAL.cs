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
    public class Kategori
    {
        public int kategoriID { get; set; }
        public string kategorinavn { get; set;}
    }
}