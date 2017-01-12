using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineKredit.web.Models
{
    public class OrtModel 
    {
        public string ID { get; set; }
        public string PLZ { get; set; }
        public string Bezeichnung { get; set; }

        public string Anzeige
        {
            get
            {
                return $"({PLZ}) {Bezeichnung}";
            }
        }
    }
}