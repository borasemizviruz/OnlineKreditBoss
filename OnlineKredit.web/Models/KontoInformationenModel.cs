using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineKredit.web.Models
{
    public class KontoInformationenModel
    {
        public int ID_Kunde { get; set; }
        public bool NeuesKonto { get; set; }

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt")]
        [DataType(DataType.Text, ErrorMessage = "Bitte geben Sie keine Sonderzeichen ein")]
        public string BankName { get; set; }

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt")]
        [DataType(DataType.Text, ErrorMessage = "Bitte geben Sie Ihren IBAN ein")]
        public string IBAN { get; set; }

        [StringLength(20, ErrorMessage = "max. 20 Zeichen erlaubt")]
        [DataType(DataType.Text, ErrorMessage = "Bitte geben Sie Ihren BIC ein")]
        public string BIC { get; set; }
    }
}