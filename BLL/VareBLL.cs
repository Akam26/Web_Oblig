using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class VareBLL
    {
        private VareDAL vareDAL;
        public VareBLL()
        {
            vareDAL = new VareDAL();
        }
        public Models.Vare BestillVare(int vareid)
        {
            return vareDAL.BestillVare(vareid);
        }
        public List<Models.Vare> listeAvVarer()
        {
            return vareDAL.listeAvVarer();
        }
    }
}
