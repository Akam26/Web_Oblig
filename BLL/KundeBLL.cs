using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;


namespace BLL
{
    public class KundeBLL
    {
        private KundeDAL kundeDAL;
        public KundeBLL()
        {
            kundeDAL = new KundeDAL();
        }

        public bool OpprettKunde(Kunde nyKunde)
        {//oppretter en ny kunde og kaller på kundeDAL for å sette inn
            string nySalt = CryptoLib.Encryptor.MD5Hash("" + new Random());
            nyKunde.salt = nySalt;
            nyKunde.passord = CryptoLib.Encryptor.MD5Hash(nyKunde.passord + nySalt);

            return kundeDAL.OpprettKunde(nyKunde);
        }

        public int loginn(string brukernavn, string passord)
        {//logger inn brkerenu
            return kundeDAL.loginn(brukernavn, passord);
        }

        public String KundeSalt(String username)
        { //returnerer brukerens salt
            return kundeDAL.KundeSalt(username);
        }

        public Models.Kunde visProfil(int kundeid)
        {//viser brukerens profil
            return kundeDAL.visProfil(kundeid);
        }
        public bool EndreKunde(Models.Kunde endreKunde)
        {//endrer kundens informasjon
            return kundeDAL.EndreProfil(endreKunde);
        }


    }
}
