using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model
{
    public class Vare
    {
        public int vareID { get; set; }
        public string navn { get; set; }
        public int pris { get; set; }
        public string merke { get; set; }
        public virtual Kategori kategori { get; set; }
        public string visBilde { get; set; }
    }
}
