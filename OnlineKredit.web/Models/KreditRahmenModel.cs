﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineKredit.web.Models
{
    public class KreditRahmenModel
    {
        [Required(ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Gewünschter Betrag")]
        [Range(1000, 1000000, ErrorMessage = "Betrag muss zwischen 1.000 € und 1.000.000 € liegen")]
        public int Betrag { get; set; }

        [Required(ErrorMessage = "Pflichtfeld")]
        [Display(Name = "Laufzeit in Monaten")]
        [Range(6,240, ErrorMessage = "Laufzeit muss zwischen 6 und 240 Monaten liegen")]
        public int Laufzeit { get; set; }
    }
}