using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineKredit.logic
{
    public class KonsumKreditVerwaltung
    {
        public static Kunde ErzeugeKunde()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - ErzeugeKunde");
            Debug.Indent();

            Kunde neuerKunde = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    neuerKunde = new logic.Kunde()
                    {
                        Vorname = "anonym",
                        Nachname = "anonym",
                        Geschlecht = "x"
                    };
                    context.AlleKunden.Add(neuerKunde);
                    int anzahlZeilenBetroffen = context.SaveChanges();
                    Debug.WriteLine($"{anzahlZeilenBetroffen} Kunden angelegt!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in ErzeugeKunde");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return neuerKunde;
        }

        public static bool KreditRahmenSpeichern(double kreditBetrag, int laufzeit, int idKunde)
        {
            Debug.WriteLine("KonsumkreditVerwaltun g - KreditRahmenSpeichern");
            Debug.Indent();

            bool erfolgreich = false;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    Kunde aktKunde = context.AlleKunden.Where(x => x.ID == idKunde).FirstOrDefault();

                    if (aktKunde != null)
                    {
                        KreditWunsch neuerKreditWunsch = new KreditWunsch()
                        {
                            Betrag = (decimal)kreditBetrag,
                            Laufzeit = laufzeit,
                            ID = idKunde
                        };

                        context.AlleKreditWünsche.Add(neuerKreditWunsch);
                    }

                    int anzahlZeilenBetroffen = context.SaveChanges();
                    erfolgreich = anzahlZeilenBetroffen >= 1;
                    Debug.WriteLine($"{anzahlZeilenBetroffen} KreditRahmen gespeichert!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in KreditRahmenSpeichern");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return erfolgreich;
        }

        public static bool FinanzielleSituationSpeichern(double nettoEinkommen, double ratenVerpflichtungen, double wohnkosten, double einkünfteAlimenteUnterhalt, double unterhaltsZahlungen, int idKunde)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - FinanzielleSituationSpeichern");
            Debug.Indent();

            bool erfolgreich = false;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {

                    Kunde aktKunde = context.AlleKunden.Where(x => x.ID == idKunde).FirstOrDefault();

                    if (aktKunde != null)
                    {
                        FinanzielleSituation neueFinanzielleSituation = new FinanzielleSituation()
                        {
                            MonatsEinkommen = (decimal)nettoEinkommen,
                            AusgabenALIUNT = (decimal)unterhaltsZahlungen,
                            EinkuenfteAlimenteUnterhalt = (decimal)einkünfteAlimenteUnterhalt,
                            Wohnkosten = (decimal)wohnkosten,
                            RatenZahlungen = (decimal)ratenVerpflichtungen,
                            ID = idKunde
                        };

                        context.AlleFinanzielleSituationen.Add(neueFinanzielleSituation);
                    }

                    int anzahlZeilenBetroffen = context.SaveChanges();
                    erfolgreich = anzahlZeilenBetroffen >= 1;
                    Debug.WriteLine($"{anzahlZeilenBetroffen} FinanzielleSituation gespeichert!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in FinanzielleSituation");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();      
            }

            Debug.Unindent();
            return erfolgreich;
        }

        public static List<Branche> BranchenLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - BranchenLaden");
            Debug.Indent();

            List<Branche> alleBranchen = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleBranchen = context.AlleBranchen.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in BranchenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleBranchen;
        }

        public static List<Beschaeftigungsart> BeschaeftigungsArtenLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - Beschaeftigungsart");
            Debug.Indent();

            List<Beschaeftigungsart> alleBeschaeftigungsArten = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleBeschaeftigungsArten = context.AlleBeschaeftigungsarten.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in Beschaeftigungsart");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleBeschaeftigungsArten;
        }

        public static List<Schulabschluss> BildungsAngabenLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - BildungsAngabenLaden");
            Debug.Indent();

            List<Schulabschluss> alleAbschlüsse = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleAbschlüsse = context.AlleSchulabschlüsse.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in BildungsAngabenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleAbschlüsse;
        }

        public static List<FamilienStandAngabe> FamilienStandAngabenLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - FamilienStandAngabenLaden");
            Debug.Indent();

            List<FamilienStandAngabe> alleFamilienStandsAngaben = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleFamilienStandsAngaben = context.AlleFamilienStandAngaben.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in FamilienStandAngabenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleFamilienStandsAngaben;
        }

        public static List<Land> LaenderLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - LaenderLaden");
            Debug.Indent();

            List<Land> alleLänder = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleLänder = context.AlleLänder.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in LaenderLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleLänder;
        }

        public static List<Wohnart> WohnartenLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - WohnartenLaden");
            Debug.Indent();

            List<Wohnart> alleWohnarten = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleWohnarten = context.AlleWohnarten.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in WohnartenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleWohnarten;
        }

        public static List<IdentifikationsArt> IdentifikiationsAngabenLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - IdentifikiationsAngabenLaden");
            Debug.Indent();

            List<IdentifikationsArt> alleIdentifikationsArten = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleIdentifikationsArten = context.AlleIdentifikationsArten.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in IdentifikiationsAngabenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleIdentifikationsArten;
        }

        public static List<Titel> TitelLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - TitelLaden");
            Debug.Indent();

            List<Titel> alleTitel = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleTitel = context.AlleTitel.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in TitelLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleTitel;
        }

        public static List<Ort> OrteLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - OrteLaden");
            Debug.Indent();

            List<Ort> alleOrte = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleOrte = context.AlleOrte.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in OrteLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleOrte;
        }


        public static List<Ort> OrtLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - TitelLaden");
            Debug.Indent();

            List<Ort> alleOrte = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleOrte = context.AlleOrte.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in TitelLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleOrte;
        }

        //public static List<PLZ> PLZLaden()
        //{
        //    Debug.WriteLine("KonsumKreditVerwaltung - PLZLaden");
        //    Debug.Indent();

        //    List<PLZ> allePLZ = null;

        //    try
        //    {
        //        using (var context = new dbOnlineKreditLAPEntities1())
        //        {
        //            allePLZ = context.PLZ.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Fehler in PLZLaden");
        //        Debug.Indent();
        //        Debug.WriteLine(ex.Message);
        //        Debug.Unindent();
        //        Debugger.Break();
        //    }

        //    Debug.Unindent();
        //    return allePLZ;
        //}

        public static bool PersönlicheDatenSpeichern(int? idTitel, string geschlecht, DateTime geburtsDatum, string vorname, string nachname, int? idTitelNachstehend, int idBildung, int idFamilienstand, int idIdentifikationsart, string identifikationsNummer, string idStaatsbuergerschaft, int idWohnart, int idKunde)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - PersönlicheDatenSpeichern");
            Debug.Indent();

            bool erfolgreich = false;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {

                    /// speichere zum Kunden die Angaben
                    Kunde aktKunde = context.AlleKunden.Where(x => x.ID == idKunde).FirstOrDefault();

                    if (aktKunde != null)
                    {
                        aktKunde.Vorname = vorname;
                        aktKunde.Nachname = nachname;
                        aktKunde.FKFamilienstand = idFamilienstand;
                        aktKunde.FKSchulabschluss = idBildung;
                        aktKunde.FKStaatsangehoerigkeit = idStaatsbuergerschaft;
                        aktKunde.FKTitel = idTitel;
                        aktKunde.FKIdentifikationsArt = idIdentifikationsart;
                        aktKunde.IdentifikationsNummer = identifikationsNummer;
                        aktKunde.Geschlecht = geschlecht;
                        aktKunde.FKWohnart = idWohnart;
                    }

                    int anzahlZeilenBetroffen = context.SaveChanges();
                    erfolgreich = anzahlZeilenBetroffen >= 1;
                    Debug.WriteLine($"{anzahlZeilenBetroffen} PersönlicheDaten gespeichert!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in PersönlicheDatenSpeichern");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return erfolgreich;
        }

        public static bool KontaktdatenSpeichern(int idOrt, string idPLZ, string mail, string telefonnummer, string strasseNR, int idKunde)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - ArbeitgeberAngabenSpeichern");
            Debug.Indent();

            bool erfolgreich = false;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {

                    /// speichere zum Kunden die Angaben
                    Kunde aktKunde = context.AlleKunden.Where(x => x.ID == idKunde).FirstOrDefault();

                    if (aktKunde != null)
                    {
                        KontaktDaten neueKontaktdaten = new KontaktDaten()
                        {
                            FKOrt = idOrt,
                            //PLZ = idPLZ,
                            EMail = mail,
                            Telefonnummer = telefonnummer,
                            StrasseNR = strasseNR
                        };
                        aktKunde.KontaktDaten = neueKontaktdaten;
                    }

                    Ort aktOrt = context.AlleOrte.Where(x => x.ID == idKunde).FirstOrDefault();

                    if (aktOrt != null)
                    {
                        Ort neueOrtdaten = new Ort()
                        {
                            PLZ = idPLZ

                        };
                        aktOrt = neueOrtdaten;
                    }

                    int anzahlZeilenBetroffen = context.SaveChanges();
                    erfolgreich = anzahlZeilenBetroffen >= 1;
                    Debug.WriteLine($"{anzahlZeilenBetroffen} KontaktDaten gespeichert!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in KontaktDatenSpeichern");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return erfolgreich;
        }

        public static bool ArbeitgeberAngabenSpeichern(string firmenName, int idBeschäftigungsArt, int idBranche, string beschäftigtSeit, int idKunde)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - ArbeitgeberAngabenSpeichern");
            Debug.Indent();

            bool erfolgreich = false;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {

                    /// speichere zum Kunden die Angaben
                    Kunde aktKunde = context.AlleKunden.Where(x => x.ID == idKunde).FirstOrDefault();

                    if (aktKunde != null)
                    {
                        Arbeitgeber neuerArbeitgeber = new Arbeitgeber()
                        {
                            BeschaeftigtSeit = DateTime.Parse(beschäftigtSeit),
                            FKBranche = idBranche,
                            FKBeschaeftigungsArt = idBeschäftigungsArt,
                            Firma = firmenName
                        };
                        aktKunde.Arbeitgeber = neuerArbeitgeber;
                    }

                    int anzahlZeilenBetroffen = context.SaveChanges();
                    erfolgreich = anzahlZeilenBetroffen >= 1;
                    Debug.WriteLine($"{anzahlZeilenBetroffen} ArbeitgeberDaten gespeichert!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in ArbeitgeberAngabenSpeichern");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return erfolgreich;
        }

        public static bool KontoInformationenSpeichern(string bankName, string iban, string bic, bool neuesKonto, int idKunde)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - KontoInformationenSpeichern");
            Debug.Indent();

            bool erfolgreich = false;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {

                    /// speichere zum Kunden die Angaben
                    Kunde aktKunde = context.AlleKunden.Where(x => x.ID == idKunde).FirstOrDefault();

                    if (aktKunde != null)
                    {
                        KontoDaten neueKontoDaten = new KontoDaten()
                        {
                            BankName = bankName,
                            IBAN = iban,
                            BIC = bic,
                            NeuesKonto = !neuesKonto,
                            ID = idKunde
                        };

                        context.AlleKontoDaten.Add(neueKontoDaten);
                    }

                    int anzahlZeilenBetroffen = context.SaveChanges();
                    erfolgreich = anzahlZeilenBetroffen >= 1;
                    Debug.WriteLine($"{anzahlZeilenBetroffen} Konto-Daten gespeichert!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in KontoInformationenSpeichern");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return erfolgreich;
        }

        public static List<Kunde> KundenLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - KundenLaden");
            Debug.Indent();

            List<Kunde> alleKunden = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleKunden = context.AlleKunden
                        .Include("Arbeitgeber")
                        .Include("Arbeitgeber.Beschaeftigungsart")
                        .Include("Arbeitgeber.Branche")
                        .Include("Familienstand")
                        .Include("FinanzielleSituation")
                        .Include("IdentifikationsArt")
                        .Include("KontaktDaten")
                        .Include("KontoDaten")
                        .Include("KreditWunsch")
                        .Include("Schulabschluss")
                        .Include("Titel")
                        .Include("TitelNachstehend")
                        .Include("Wohnart")
                        .Include("Staatsangehoerigkeit")
                        .OrderByDescending(x => x.ID)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in KundenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleKunden;
        }

        public static List<Kunde> LetzteKundenLaden()
        {
            Debug.WriteLine("KonsumKreditVerwaltung - LetzteKundenLaden");
            Debug.Indent();

            List<Kunde> alleKunden = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    alleKunden = context.AlleKunden
                        .Include("Arbeitgeber")
                        .Include("Arbeitgeber.BeschaeftigungsArt")
                        .Include("Arbeitgeber.Branche")
                        .Include("Familienstand")
                        .Include("FinanzielleSituation")
                        .Include("IdentifikationsArt")
                        .Include("KontaktDaten")
                        .Include("KontoDaten")
                        .Include("KreditWunsch")
                        .Include("Schulabschluss")
                        .Include("Titel")
                        .Include("TitelNachstehend")
                        .Include("Wohnart")
                        .Include("Staatsangehoerigkeit")
                        .OrderByDescending(x => x.ID)
                        .Take(10)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in LetzteKundenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return alleKunden;
        }

        public static Kunde KundeLaden(int idKunde)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - KundeLaden");
            Debug.Indent();

            Kunde aktuellerKunde = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    aktuellerKunde = context.AlleKunden
                        .Include("Arbeitgeber")
                        .Include("Arbeitgeber.AlleBeschaeftigungsarten")
                        .Include("Arbeitgeber.AlleBranchen")
                        .Include("Familienstand")
                        .Include("FinanzielleSituation")
                        .Include("IdentifikationsArt")
                        .Include("KontaktDaten.Ort")
                        .Include("KontaktDaten")
                        .Include("KontoDaten")
                        .Include("KreditWunsch")
                        .Include("Schulabschluss")
                        .Include("Titel")
                        .Include("Wohnart")
                        .Include("Land")
                        .Where(x => x.ID == idKunde).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in KundeLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return aktuellerKunde;
        }



        /// <summary>
        /// Lädt den Kunden für die übergebene ID
        /// </summary>
        /// <param name="id">die id des zu ladenden Kunden</param>
        /// <returns>der Kunde für die übergebene ID</returns>
        public static Kunde PersönlicheDatenLaden(int id)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - PersönlicheDatenLaden");
            Debug.Indent();

            Kunde persönlicheDaten = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    persönlicheDaten = context.AlleKunden.Where(x => x.ID == id).FirstOrDefault();
                    Debug.WriteLine("PersönlicheDatenLaden geladen!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in PersönlicheDatenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return persönlicheDaten;
        }


        /// <summary>
        /// Lädt den Kreditrahmen für die übergebene ID
        /// </summary>
        /// <param name="id">die id des zu ladenden Kreditrahmens</param>
        /// <returns>der Kreditwunsch für die übergebene ID</returns>
        public static Arbeitgeber ArbeitgeberAngabenLaden(int id)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - ArbeitgeberAngabenLaden");
            Debug.Indent();

            Arbeitgeber arbeitGeber = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    arbeitGeber = context.AlleArbeitgeber.Where(x => x.ID == id).FirstOrDefault();
                    Debug.WriteLine("ArbeitgeberAngaben geladen!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in ArbeitgeberAngabenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return arbeitGeber;
        }

       

        /// <summary>
        /// Lädt die KontoDaten für die übergebene ID
        /// </summary>
        /// <param name="id">die id der zu ladenden KontoDaten</param>
        /// <returns>die KontoDaten für die übergebene ID</returns>
        public static KontoDaten KontoInformationenLaden(int id)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - KontoInformationenLaden");
            Debug.Indent();

            KontoDaten kontoDaten = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    kontoDaten = context.AlleKontoDaten.Where(x => x.ID == id).FirstOrDefault();
                    Debug.WriteLine("KontoInformationen geladen!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in KontoInformationenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return kontoDaten;
        }

        public static Ort KundenOrtLaden(int id)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - KundenOrtLaden");
            Debug.Indent();

            Ort Ort = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    Ort = context.AlleOrte.Where(x => x.ID == id).FirstOrDefault();
                    Debug.WriteLine("KundenOrtLaden geladen!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in KundenOrtLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return Ort;
        }



        //public static void EntferneErsteZiffer()
        //{
        //    if (true)
        //    {

        //    }
        //}


        public static KontaktDaten KontaktDatenLaden(int id)
        {
            Debug.WriteLine("KonsumKreditVerwaltung - KontoInformationenLaden");
            Debug.Indent();

            KontaktDaten kontaktDaten = null;

            try
            {
                using (var context = new dbOnlineKreditLAPEntities1())
                {
                    kontaktDaten = context.AlleKontaktDaten.Where(x => x.ID == id).FirstOrDefault();
                    Debug.WriteLine("KontaktDaten geladen!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fehler in KontaktDatenLaden");
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                Debugger.Break();
            }

            Debug.Unindent();
            return kontaktDaten;
        }


    }
}
