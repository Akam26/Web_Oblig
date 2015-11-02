using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using System.Data.Entity;
using System.Web;
//using System.Data.Entity.ModelConfiguration.Conventions;

namespace Models
{
    public class Bestilling
    {
        [Key]
        public int ordreID { get; set; }
        public virtual Kunde kundeID { get; set; }
        public virtual Vare vareID { get; set; }
        public DateTime tid { get; set; }
    }


}
