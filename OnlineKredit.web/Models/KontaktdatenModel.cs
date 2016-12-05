using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineKredit.web.Models
{
    public class KontaktdatenModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Straße/Hausnummer")]
        public string StrasseNR { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Ort")]
        public int ID_Ort { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [Display(Name = "E-Mail")]
        public string Mail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Telefonnummer")]
        public string TelefonNummer { get; set; }

        public List<OrtModel> AlleOrte { get; set; }

        public int ID_Kunde { get; set; }
    }
}