using OnlineKredit.logic;
using OnlineKredit.freigabe;
using OnlineKredit.web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineKredit.web.Controllers
{
    public class KonsumKreditController : Controller
    {
        [HttpGet]
        public ActionResult KreditRahmen()
        {
            Debug.WriteLine("GET - KonsumKredit - KreditRahmen");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KreditRahmen(KreditRahmenModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - KreditRahmen");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                Kunde neuerKunde = KonsumKreditVerwaltung.ErzeugeKunde();

                if (neuerKunde != null && KonsumKreditVerwaltung.KreditRahmenSpeichern(model.Betrag, model.Laufzeit, neuerKunde.ID))
                {
                    /// ich benötige für alle weiteren Schritte die ID
                    /// des angelegten Kunden. Damit ich diese bei der nächsten Action
                    /// habe, speichere ich sie für diesen Zweck in ein Cookie
                    Response.Cookies.Add(new HttpCookie("idKunde", neuerKunde.ID.ToString()));

                    /// gehe zum nächsten Schritt
                    return RedirectToAction("FinanzielleSituation");
                }
            }

            /// falls der ModelState NICHT valid ist, bleibe hier und
            /// gib die Daten (falls vorhanden) wieder auf das UI
            return View(model);
        }

        [HttpGet]
        public ActionResult FinanzielleSituation()
        {
            Debug.WriteLine("GET - KonsumKredit - FinanzielleSituation");

            FinanzielleSituationModel model = new FinanzielleSituationModel()
            {
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FinanzielleSituation(FinanzielleSituationModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - FinanzielleSituation");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                if (KonsumKreditVerwaltung.FinanzielleSituationSpeichern(
                                                model.NettoEinkommen,
                                                model.RatenVerpflichtungen,
                                                model.Wohnkosten,
                                                model.EinkünfteAlimenteUnterhalt,
                                                model.UnterhaltsZahlungen,
                                                model.ID_Kunde))
                {
                    return RedirectToAction("PersönlicheDaten");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult PersönlicheDaten()
        {
            Debug.WriteLine("GET - KonsumKredit - PersönlicheDaten");

            List<BildungsModel> alleBildungsAngaben = new List<BildungsModel>();
            List<FamilienStandModel> alleFamilienStandAngaben = new List<FamilienStandModel>();
            List<IdentifikationsModel> alleIdentifikationsAngaben = new List<IdentifikationsModel>();
            List<StaatsbuergerschaftsModel> alleStaatsbuergerschaftsAngaben = new List<StaatsbuergerschaftsModel>();
            List<TitelModel> alleTitelAngaben = new List<TitelModel>();
            List<WohnartModel> alleWohnartAngaben = new List<WohnartModel>();
            List<TitelNachstehendModel> alleTitelNachstehenAngaben = new List<TitelNachstehendModel>();

            /// Lade Daten aus Logic
            foreach (var bildungsAngabe in KonsumKreditVerwaltung.BildungsAngabenLaden())
            {
                alleBildungsAngaben.Add(new BildungsModel()
                {
                    ID = bildungsAngabe.ID.ToString(),
                    Bezeichnung = bildungsAngabe.Bezeichnung
                });
            }

            foreach (var familienStand in KonsumKreditVerwaltung.FamilienStandAngabenLaden())
            {
                alleFamilienStandAngaben.Add(new FamilienStandModel()
                {
                    ID = familienStand.ID.ToString(),
                    Bezeichnung = familienStand.Bezeichnung
                });
            }
            foreach (var identifikationsAngabe in KonsumKreditVerwaltung.IdentifikiationsAngabenLaden())
            {
                alleIdentifikationsAngaben.Add(new IdentifikationsModel()
                {
                    ID = identifikationsAngabe.ID.ToString(),
                    Bezeichnung = identifikationsAngabe.Bezeichnung
                });
            }
            foreach (var land in KonsumKreditVerwaltung.LaenderLaden())
            {
                alleStaatsbuergerschaftsAngaben.Add(new StaatsbuergerschaftsModel()
                {
                    ID = land.ID,
                    Bezeichnung = land.Bezeichnung
                });
            }
            foreach (var titel in KonsumKreditVerwaltung.TitelLaden())
            {
                alleTitelAngaben.Add(new TitelModel()
                {
                    ID = titel.ID.ToString(),
                    Bezeichnung = titel.Bezeichnung
                });
            }
            foreach (var wohnart in KonsumKreditVerwaltung.WohnartenLaden())
            {
                alleWohnartAngaben.Add(new WohnartModel()
                {
                    ID = wohnart.ID.ToString(),
                    Bezeichnung = wohnart.Bezeichnung
                });
            }
            


            PersönlicheDatenModel model = new PersönlicheDatenModel()
            {
                AlleBildungAngaben = alleBildungsAngaben,
                AlleFamilienStandAngaben = alleFamilienStandAngaben,
                AlleIdentifikationsAngaben = alleIdentifikationsAngaben,
                AlleStaatsbuergerschaftsAngaben = alleStaatsbuergerschaftsAngaben,
                AlleTitelAngaben = alleTitelAngaben,
                AlleTitelNachstehendAngaben = alleTitelNachstehenAngaben,
                AlleWohnartAngaben = alleWohnartAngaben,
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersönlicheDaten(PersönlicheDatenModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - PersönlicheDaten");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                if (KonsumKreditVerwaltung.PersönlicheDatenSpeichern(
                                                model.ID_Titel,
                                                model.Geschlecht == Geschlecht.Männlich ? "m" : "w",
                                                model.GeburtsDatum,
                                                model.Vorname,
                                                model.Nachname,
                                                model.ID_TitelNachstehend,
                                                model.ID_Bildung,
                                                model.ID_Familienstand,
                                                model.ID_Identifikationsart,
                                                model.IdentifikationsNummer,
                                                model.ID_Staatsbuergerschaft,
                                                model.ID_Wohnart,
                                                model.ID_Kunde))
                {
                    return RedirectToAction("Kontaktdaten");
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult Kontaktdaten()
        {
            Debug.WriteLine("GET - KonsumKredit - Kontaktdaten");

            List<OrtModel> alleOrte = new List<OrtModel>();

            foreach (var ort in KonsumKreditVerwaltung.OrteLaden())
            {
                alleOrte.Add(new OrtModel()
                {
                    ID = ort.ID.ToString(),
                    Bezeichnung = ort.Bezeichnung
                });
            }

            KontaktdatenModel model = new KontaktdatenModel()
            {
                AlleOrte = alleOrte,
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kontaktdaten(KontaktdatenModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - KontaktDaten");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                if (KonsumKreditVerwaltung.KontaktdatenSpeichern(

                                                model.ID_Ort,
                                                model.StrasseNR,
                                                model.Mail,
                                                model.TelefonNummer,
                                                model.ID_Kunde))
                {
                    return RedirectToAction("Arbeitgeber");
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult Arbeitgeber()
        {
            Debug.WriteLine("GET - KonsumKredit - Arbeitgeber");

            List<BeschaeftigungsArtModel> alleBeschaeftigungen = new List<BeschaeftigungsArtModel>();
            List<BrancheModel> alleBranchen = new List<BrancheModel>();

            foreach (var branche in KonsumKreditVerwaltung.BranchenLaden())
            {
                alleBranchen.Add(new BrancheModel()
                {
                    ID = branche.ID.ToString(),
                    Bezeichnung = branche.Bezeichnung
                });
            }

            foreach (var beschaeftigungsart in KonsumKreditVerwaltung.BeschaeftigungsArtenLaden())
            {
                alleBeschaeftigungen.Add(new BeschaeftigungsArtModel()
                {
                    ID = beschaeftigungsart.ID.ToString(),
                    Bezeichnung = beschaeftigungsart.Bezeichnung
                });
            }

            ArbeitgeberModel model = new ArbeitgeberModel()
            {
                AlleBeschaeftigungen = alleBeschaeftigungen,
                AlleBranchen = alleBranchen,
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Arbeitgeber(ArbeitgeberModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - Arbeitgeber");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                if (KonsumKreditVerwaltung.ArbeitgeberAngabenSpeichern(
                                                model.FirmenName,
                                                model.ID_BeschäftigungsArt,
                                                model.ID_Branche,
                                                model.BeschäftigtSeit,
                                                model.ID_Kunde))
                {
                    return RedirectToAction("KontoInformationen");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult KontoInformationen()
        {
            Debug.WriteLine("GET - KonsumKredit - KontoInformationen");

            KontoInformationenModel model = new KontoInformationenModel()
            {
                ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value)
            };

            KontoDaten daten = KonsumKreditVerwaltung.KontoInformationenLaden(model.ID_Kunde);
            if (daten != null)
            {
                model.BankName = daten.BankName;
                model.BIC = daten.BIC;
                model.IBAN = daten.IBAN;
                model.NeuesKonto = !daten.NeuesKonto.Value;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KontoInformationen(KontoInformationenModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - KontoInformationen");

            if (ModelState.IsValid)
            {
                /// speichere Daten über BusinessLogic
                if (KonsumKreditVerwaltung.KontoInformationenSpeichern(
                                                model.BankName,
                                                model.IBAN,
                                                model.BIC,
                                                model.NeuesKonto,
                                                model.ID_Kunde))
                {
                    return RedirectToAction("Zusammenfassung");
                }
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Zusammenfassung(ZusammenfassungModel model)
        {
            Debug.WriteLine("POST - KonsumKredit - Zusammenfassung");
            return View();
        }

        [HttpGet]
        public ActionResult Zusammenfassung()
        {
            Debug.WriteLine("GET - KonsumKredit - Zusammenfassung");

            /// ermittle für diese Kunden_ID
            /// alle gespeicherten Daten (ACHTUNG! das sind viele ....)
            /// gib Sie alle in das ZusammenfassungsModel (bzw. die UNTER-Modelle) 
            /// hinein.
            ZusammenfassungModel model = new ZusammenfassungModel();
            model.ID_Kunde = int.Parse(Request.Cookies["idKunde"].Value);

            /// lädt ALLE Daten zu diesem Kunden (also auch die angehängten/referenzierten
            /// Entities) aus der DB
            Kunde aktKunde = KonsumKreditVerwaltung.KundeLaden(model.ID_Kunde);
            Ort aktOrt = KonsumKreditVerwaltung.KundenOrtLaden(model.ID_Kunde);

            model.GewünschterBetrag = (int)aktKunde.KreditWunsch.Betrag.Value;
            model.Laufzeit = aktKunde.KreditWunsch.Laufzeit.Value;

            model.NettoEinkommen = (double)aktKunde.FinanzielleSituation.MonatsEinkommen.Value;
            model.Wohnkosten = (double)aktKunde.FinanzielleSituation.Wohnkosten.Value;
            model.EinkünfteAlimenteUnterhalt = (double)aktKunde.FinanzielleSituation.EinkuenfteAlimenteUnterhalt.Value;
            model.UnterhaltsZahlungen = (double)aktKunde.FinanzielleSituation.AusgabenALIUNT.Value;
            model.RatenVerpflichtungen = (double)aktKunde.FinanzielleSituation.RatenZahlungen.Value;

            model.Geschlecht = aktKunde.Geschlecht == "m" ? "Herr" : "Frau";
            model.Vorname = aktKunde.Vorname;
            model.Nachname = aktKunde.Nachname;
            model.Titel = aktKunde.Titel?.Bezeichnung;
            model.GeburtsDatum = DateTime.Now;
            model.Familienstand = aktKunde.FamilienStand?.Bezeichnung;
            model.Staatsbuergerschaft = aktKunde.Land?.Bezeichnung;
            model.AnzahlUnterhaltspflichtigeKinder = -1;
            
            model.Wohnart = aktKunde.Wohnart?.Bezeichnung;
            model.Bildung = aktKunde.Schulabschluss?.Bezeichnung;
            model.Identifikationsart = aktKunde.IdentifikationsArt?.Bezeichnung;
            model.IdentifikationsNummer = aktKunde.IdentifikationsNummer;

            model.FirmenName = aktKunde.Arbeitgeber?.Firma;
            model.BeschäftigungsArt = aktKunde.Arbeitgeber?.AlleBeschaeftigungsarten?.Bezeichnung;
            model.Branche = aktKunde.Arbeitgeber?.AlleBranchen?.Bezeichnung;
            model.BeschäftigtSeit = aktKunde.Arbeitgeber?.BeschaeftigtSeit.Value.ToShortDateString();

            model.Strasse = aktKunde.KontaktDaten?.StrasseNR;
            model.Ort = aktOrt.Bezeichnung;
            model.PLZ = aktOrt.PLZ;
            model.Mail = aktKunde.KontaktDaten?.EMail;
            model.TelefonNummer = aktKunde.KontaktDaten?.Telefonnummer;

            model.NeuesKonto = (bool)aktKunde.KontoDaten?.NeuesKonto.Value;
            model.BankName = aktKunde.KontoDaten?.BankName;
            model.IBAN = aktKunde.KontoDaten?.IBAN;
            model.BIC = aktKunde.KontoDaten?.BIC;

            /// gib model an die View
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bestätigung(int id, bool? bestätigt)
        {
            if (bestätigt.HasValue && bestätigt.Value)
            {
                Debug.WriteLine("POST - KonsumKredit - Bestätigung");
                Debug.Indent();


                //int idKunde = int.Parse(Request.Cookies["idKunde"].Value);
                Kunde aktKunde = KonsumKreditVerwaltung.KundeLaden(id);
                Response.Cookies.Remove("idKunde");

                bool istFreigegeben = KreditFreigabe.FreigabeErteilt(
                                                            aktKunde.Geschlecht,
                                                            aktKunde.Vorname,
                                                            aktKunde.Nachname,
                                                            aktKunde.FamilienStand.Bezeichnung,
                                                            (double)aktKunde.FinanzielleSituation.MonatsEinkommen,
                                                            (double)aktKunde.FinanzielleSituation.Wohnkosten,
                                                            (double)aktKunde.FinanzielleSituation.EinkuenfteAlimenteUnterhalt,
                                                            (double)aktKunde.FinanzielleSituation.AusgabenALIUNT,
                                                            (double)aktKunde.FinanzielleSituation.RatenZahlungen);

                /// Rüfe Service/DLL auf und prüfe auf Kreditfreigabe
                Debug.WriteLine($"Kreditfreigabe {(istFreigegeben ? "" : "nicht")}erteilt!");

                Debug.Unindent();
                return RedirectToAction("Index", "Freigabe", new { erfolgreich = istFreigegeben });

            }
            else
            {
                return RedirectToAction("Zusammenfassung");
            }
        }


    }

}