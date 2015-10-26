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


namespace Web_Oblig1.Models
{
    public class Kunde
    {
        [Key]
        public int kundeID { get; set; }


        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        public string fornavn { get; set; }

        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis")]
        public string etterNavn { get; set; }



        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Adresse må oppgis")]
        public string adresse { get; set; }


        [Display(Name = "Brukernavn")]
        [Required(ErrorMessage = "Brukernavn må oppgis")]
        public string brukerNavn { get; set; }

        [Display(Name = "Passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        public string passord { get; set; }
        public string salt { get; set; }
    }

} 