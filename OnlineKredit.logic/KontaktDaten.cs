//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineKredit.logic
{
    using System;
    using System.Collections.Generic;
    
    public partial class KontaktDaten
    {
        public int ID { get; set; }
        public Nullable<int> FKOrt { get; set; }
        public string EMail { get; set; }
        public string Telefonnummer { get; set; }
        public string StrasseNR { get; set; }
    
        public virtual Ort Ort { get; set; }
        public virtual Kunde Kunde { get; set; }
    }
}
