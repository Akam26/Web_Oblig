/*
* s198596 Akam Neeson
* s198518 Magnus Molaug
* s198572 Ali Mohammad
* s198574 Marius Strømme    
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Oblig1.Models
{
    public class VareModel
    {
        public int vareID { get; set; }
        public string navn { get; set; }
        public int pris { get; set; }
        public string merke { get; set; }
        public virtual Kategori kategori { get; set; }
        public string visBilde { get; set; }
    }
}