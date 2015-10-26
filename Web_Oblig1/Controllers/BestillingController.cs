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
using System.Web.Mvc;
using System.Web.SessionState;
using System.Net.Http;
using Web_Oblig1.Models;

namespace Web_Oblig1.Controllers
{
    public class BestillingController : Controller
    {
        // GET: Bestillling
        public ActionResult ListAlleBestillinger()
        {
            var db = new Models.BestillingContext();
            //*******1******
            /*var bestillinger = db.Bestillinger.ToList();
            var bes = new List<int>();
            foreach(var b in bestillinger)
            {
                if (!bes.Contains(b.ordreID))
                {
                    bes.Add(b.ordreID);
                }
                return View(bes);
            }*/
            //*********************
             List<Models.Bestilling> listeAvBrukere = db.Bestillinger.ToList();
             //ViewData.Model = listeAvBrukere;
             ViewData["Melding"] = "Velg noe her: ";
             //return View();
            //List<Models.Vare> listeAvBestillinger = db.Varer.ToList();
            List<Models.Bestilling> listeAvBestillinger = db.Bestillinger.ToList();
            return View(listeAvBestillinger);
        }

        //***********2*********
        public String hentBestillinger(int kundeid)
        {

            using(var db = new Models.BestillingContext())
            {
                List<Models.Bestilling> bestillinger = db.Bestillinger.Where(s => s.kundeID.kundeID == kundeid).ToList();

                //JsonResult json = Json(bestillinger, JsonRequestBehavior.AllowGet);

                String ut = "";
                foreach(var b in bestillinger)
                {
                    ut += "<table>" +
                            "<tr><td>OrdreID: </td><td>" + b.ordreID.ToString() + "</td></tr>" +
                            "<tr><td>KundeID: </td><td>" + b.kundeID.kundeID + "</td></tr>" +
                            "<tr><td>Navn: </td><td>" + b.kundeID.fornavn + " " + b.kundeID.etterNavn + "</td></tr>" +
                            "<tr><td>VareID: </td><td>" + b.vareID.vareID + "</td></tr>" +
                            "<tr><td>Vare: </td><td>" + b.vareID.navn + "</td></tr>" +
                            "<tr><td>Dato: </td><td>" + b.tid.ToString() + "</td></tr>" +
                            "</table><hr/>";
                }
                //return json; //hvis dere skal bruke JSON-metoden
                return ut;
            }
        }

       public ActionResult BestillVare(int vareid = 0) {
            var db = new Models.BestillingContext();
            Models.Vare vare = db.Varer.Find(vareid);
            if(vare == null)
            {
                return HttpNotFound();
            }
            return View(vare);
         } //Viser varen og fylle ut skjema

        [HttpPost]
       public ActionResult BestillVare(FormCollection innListe) {
            int ordreid;
            using (var db = new BestillingContext())
            {
                int vareID = Int32.Parse(innListe["vareID"]);
                int kundeID = Int32.Parse(innListe["kundeID"]);
                Bestilling nyBestilling = new Bestilling();
                nyBestilling.tid = DateTime.Now;
                Kunde k = db.Kunder.FirstOrDefault(kunde => kunde.kundeID == kundeID);
                nyBestilling.kundeID = k;//koble til kunde
                Vare v = db.Varer.FirstOrDefault(vare => vare.vareID == vareID);
                nyBestilling.vareID = v;//koble til vare
                db.Bestillinger.Add(nyBestilling);
                db.SaveChanges();

                ordreid = nyBestilling.ordreID;
            }
            return RedirectToAction("visKvitering", new { ordreid });
                //return View();
        } //trykket på Bestill
        public ActionResult OpprettKunde()
        {
            return View();
        }
        public ActionResult visAlleKategorier()
        {
            var db = new Models.BestillingContext();
            //hent alle varer med kategori = k.id;
            List<Models.Vare> listeAvVarer = db.Varer.ToList();
            
            //Det er den delen som man kan sette vare i database som er kommentert
           /*var vare1 = new Models.Vare()
            {
                navn = "mac",
                pris = 9000,
                merke = "apple",
                visBilde = "C:\\Users\\Akam\\Documents\\Visual Studio 2015\\Projects\\Web_Oblig1\\Web_Oblig1\\Resources\\mac.jpg"
            };
            var katData = db.Varekategorier.FirstOrDefault(k => k.kategoriID == 1);
            var katMobil = db.Varekategorier.FirstOrDefault(k => k.kategoriID == 2);

            vare1.kategori = katData;
            //vare1.kategori = katMobil;
            db.Varer.Add(vare1);*/
            db.SaveChanges();
            return View(listeAvVarer);
        }

        [HttpPost]
        public ActionResult OpprettKunde(FormCollection innListe)
        {
                
            try
            {
                using (var db = new Models.BestillingContext())
                {
                    string innBrukernavn = innListe["Brukernavn"];
                    var funnetBrukernavn = db.Kunder.FirstOrDefault(p => p.brukerNavn == innBrukernavn);
                    
                    if (funnetBrukernavn == null)
                    {
                        var nyKunde = new Models.Kunde();
                        nyKunde.fornavn = innListe["Fornavn"];
                        nyKunde.etterNavn = innListe["Etternavn"];
                        nyKunde.adresse = innListe["Adresse"];
                        nyKunde.brukerNavn = innListe["Brukernavn"];
                        string nySalt = CryptoLib.Encryptor.MD5Hash("" + new Random());
                        nyKunde.salt = nySalt;
                        nyKunde.passord = CryptoLib.Encryptor.MD5Hash(innListe["Passord"] + nySalt);

                        db.Kunder.Add(nyKunde);
                        db.SaveChanges();
                        return RedirectToAction("");
                    }
                    else
                    {
                        ViewBag.Feilmelding = "Du er allerede registrert.";
                        return View();
                    }

                }
            }
            catch(Exception e)
            {
                ViewBag.Feilmelding = e.Message;
                return View();
            }
                         

        }

        private static Kunde KundeID(string brukernavn, string passord)
        {
            using (var db = new Models.BestillingContext())
            {
                // string innPassord = innBruker.passord;
                //byte[] passordDb = lagHash(innBruker.Passord);
                Models.Kunde funnetBruker = db.Kunder.FirstOrDefault(b => b.passord == passord && b.brukerNavn == brukernavn);               
                if (funnetBruker != null)
                {
                    return funnetBruker;
                }
                else
                {
                    
                    return null;
                }
            }
        }

        private static string KundeSalt(string u)
        {
            using (var db = new Models.BestillingContext())
            {
                Models.Kunde funnetBruker = db.Kunder.FirstOrDefault(b => b.brukerNavn == u);
                if (funnetBruker == null)
                    return null;
                else
                    return funnetBruker.salt;
            }
        }

        public ActionResult visProfil(int kundeid = 0)
        {
            var db = new Models.BestillingContext();
            Models.Kunde kunde = db.Kunder.Find(kundeid);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            return View(kunde);
        }

        public ActionResult visKvitering(int ordreID = 0)
        {
            var db = new Models.BestillingContext();
            Models.Bestilling bestilling = db.Bestillinger.Find(ordreID);
            if(bestilling==null)
            {
                return HttpNotFound();
            }
            return View(bestilling);      
        }
        
        [HttpPost]
        public ActionResult EndreKunde(int kundeID,Kunde endreKunde)
        {
            
                
                var db = new BestillingContext();
                Models.Kunde kunde = db.Kunder.Find(kundeID);
                bool endringOk = EndreProfil(endreKunde);
                if(endringOk)
                {
                    return RedirectToAction("visAlleKategorier");
                }
           
            return View();
        }
        public ActionResult EndreKunde(int kundeID)
        {
                var db = new BestillingContext();
                Models.Kunde kunde = db.Kunder.Find(kundeID);
                return View(kunde);
        }


        [HttpPost]
        public bool EndreProfil(Kunde innKunde)
        {
            var db = new Models.BestillingContext();
            try {
                Kunde kundeendre = db.Kunder.Find(innKunde.kundeID);
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



        /* public ActionResult slettBruker(int kundeid = 0)
         {
             var db = new Models.BestillingContext();


         }*/

        [HttpPost] 
        public ActionResult loggetInn(string u, string p)
        {
            u = Request.Form["username"];
            p = Request.Form["password"];
            p = CryptoLib.Encryptor.MD5Hash(p + KundeSalt(u));
            Kunde k = KundeID(u, p);
            if (k != null)
            {
                Session["kundeID"] = k.kundeID;
                Session["innlogget"] =true;
            }
            else
            {
                Session["innlogget"] = null;
                return RedirectToAction("");
            }

            return RedirectToAction("visAlleKategorier");
        }
        public ActionResult loggetUt()
        {
            Session["innlogget"] = null;
            return RedirectToAction("visAlleKategorier");
        }

    }

}