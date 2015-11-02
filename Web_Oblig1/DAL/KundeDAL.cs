using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace DAL
{
    public class KundeDAL
    {
        private DBContext.Db db;
        public KundeDAL()
        {//konstruktør
            db = new DBContext.Db();
        }

        private bool finnesKunde(Models.Kunde testKunde)
        {//sjekker om kunden testKunde eksisterer fra før
            var funnetBrukernavn = db.Kunder.FirstOrDefault(p => p.brukerNavn == testKunde.brukerNavn);
            if (funnetBrukernavn == null)
            {
                return true;
            }
            return false;
        }
        public bool OpprettKunde(Models.Kunde nyKunde)
        {//oppretter en ny kunde i databasen
            if (finnesKunde(nyKunde))
            {//sjekker om kunden nyKunde eksisterer fra før
                try
                {//prøver å sette inn kunden nyKunde
                    db.Kunder.Add(nyKunde);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {//hvis database innsetningen ikke fungerer
                    return false;
                }
            }
            else
            {//hvis kunden nyKunde finnes fra før
                return false;
            }
        }
        public int loginn(string brukernavn, string passord)
        {//returnerer en kunde dersom loginndetaljene er korrekte
            String salt = KundeSalt(brukernavn);
            passord = CryptoLib.Encryptor.MD5Hash(passord + salt);
            var kunde = db.Kunder.FirstOrDefault(b => b.passord == passord && b.brukerNavn == brukernavn);
            if (kunde != null)
            {
                return kunde.kundeID;
            }
            else
            {
                return 0;
            }
        }
        public String KundeSalt(String username)
        {//Returnerer saltet til brukeren
            Models.Kunde funnetBruker = db.Kunder.FirstOrDefault(b => b.brukerNavn == username);
            if (funnetBruker == null)
                return null;
            else
                return funnetBruker.salt;
        }

        public Models.Kunde visProfil(int kundeid)
        {
            return db.Kunder.Find(kundeid);
        }

        public bool EndreProfil(Models.Kunde innKunde)
        {
            try
            {
                Models.Kunde kundeendre = db.Kunder.Find(innKunde.kundeID);
                kundeendre.fornavn = innKunde.fornavn;
                kundeendre.etterNavn = innKunde.etterNavn;
                kundeendre.adresse = innKunde.adresse;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
