﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineKredit.web.Models
{
    public class KontaktdatenModel
    {
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        public int ID_PLZ { get; set; }
        public string Mail { get; set; }
        public string TelefonNummer { get; set; }
    }
}