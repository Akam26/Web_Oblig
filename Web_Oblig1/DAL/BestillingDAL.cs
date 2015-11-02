using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace DAL
{
    public class BestillingDAL
    {
        private DBContext.Db db;
        public BestillingDAL()
        {//konstruktør
            db = new DBContext.Db();
        }
        public List<Models.Bestilling> ListAlleBestillinger()
        {
            return db.Bestillinger.ToList();
        }
        public List<Models.Bestilling> hentBestillinger(int kundeid)
        {
            return db.Bestillinger.Where(s => s.kundeID.kundeID == kundeid).ToList();
        }

        public Models.Bestilling visKvitering(int ordreID)
        {
            //return db.Bestillinger.Find(ordreID);
            return db.Bestillinger.FirstOrDefault(b => b.ordreID == ordreID);
        }
        public int bestillVare(int kundeid, int vareid)
        {
            Bestilling nyBestilling = new Bestilling();
            nyBestilling.tid = DateTime.Now;
            Kunde k = db.Kunder.FirstOrDefault(kunde => kunde.kundeID == kundeid);
            nyBestilling.kundeID = k;//koble til kunde
            Vare v = db.Varer.FirstOrDefault(vare => vare.vareID == vareid);
            nyBestilling.vareID = v;//koble til vare
            db.Bestillinger.Add(nyBestilling);
            db.SaveChanges();

            return nyBestilling.ordreID;
        }
    }
}
