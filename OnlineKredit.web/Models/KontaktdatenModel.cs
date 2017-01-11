using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineKredit.web.Models
{
    public class KontaktdatenModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Text, ErrorMessage = "Bitte geben Sie keine Sonderzeichen ein")]
        [Display(Name = "Straße/Hausnummer")]
        public string StrasseNR { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Ort")]
        public int ID_Ort { get; set; }
   
        public int ID_PLZ { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Bitte geben Sie Ihre Email-Adresse an")]
        [Display(Name = "E-Mail")]
        public string Mail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Telefonnummer")]
        public string TelefonNummer { get; set; }

        public List<OrtModel> AlleOrte { get; set; }

        public int ID_Kunde { get; set; }
    }
}