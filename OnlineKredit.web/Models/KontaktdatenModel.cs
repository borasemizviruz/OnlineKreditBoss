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
        [RegularExpression(@"^[\w*]+[\s]+([\d\w-]*)+([/]?)+([\s]?)+([\d\w-]*)+([/]?)+([\s]?)+([\d\w-]*)$", ErrorMessage = "Bitte geben Sie Ihre Adresse ein.")]
        [Display(Name = "Straße/Hausnummer")]
        public string StrasseNR { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [Display(Name = "PLZ, Ort")]
        public int ID_Ort { get; set; }
   
        public string PLZ { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "Bitte geben Sie Ihre Email-Adresse an")]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Mail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [RegularExpression(@"^[+ 0-9 /]+$", ErrorMessage = "Bitte geben Sie Ihre Telefonnummer ein.")]
        [Display(Name = "Telefonnummer")]
        public string TelefonNummer { get; set; }

        public List<OrtModel> AlleOrte { get; set; }

        public string OrtundPLZ { get; set; }

        public int ID_Kunde { get; set; }
    }
}