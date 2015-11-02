using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class BestillingBLL
    {
        private BestillingDAL bestillingDAL;
        public BestillingBLL()
        {
            bestillingDAL = new BestillingDAL();
        }
        public List<Models.Bestilling> ListAlleBestillinger()
        {
            List<Models.Bestilling> listeAvBestillinger = bestillingDAL.ListAlleBestillinger();
            return listeAvBestillinger;
        }
        public List<Models.Bestilling> hentBestillinger(int kundeid)
        {
            return bestillingDAL.hentBestillinger(kundeid);
        }
        public Models.Bestilling visKvitering(int ordreID)
        {
            return bestillingDAL.visKvitering(ordreID);
        }
        public int bestillVare(int kundeid, int vareid)
        {
            return bestillingDAL.bestillVare(kundeid, vareid);
        }
    }
}
