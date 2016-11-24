﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineKredit.web.Models
{
    public class ZusammenfassungModel
    {
        public KreditRahmenModel KreditRahmen { get; set; }
        public FinanzielleSituationModel FinanzielleSituation { get; set; }
        public PersönlicheDatenModel PersönlicheDaten { get; set; }
        public ArbeitgeberModel Arbeitgeber { get; set; }
        public KontaktdatenModel KontaktDaten { get; set; }
        public KontoInformationenModel KontoInformationen { get; set; }

        public int ID_Kunde { get; set; }
    }
}