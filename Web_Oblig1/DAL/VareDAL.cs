using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace DAL
{
    public class VareDAL
    {
        private DBContext.Db db;
        public VareDAL()
        {//konstruktør
            db = new DBContext.Db();
        }
        public Models.Vare BestillVare(int vareid)
        {
            return db.Varer.Find(vareid);
        }
        public List<Models.Vare> listeAvVarer()
        {
            return db.Varer.ToList();
        }
    }
}
