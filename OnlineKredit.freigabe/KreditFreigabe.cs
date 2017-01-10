using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineKredit.freigabe
{
    public class KreditFreigabe
    {
        public static bool FreigabeErteilt(
            string geschlecht,
            string vorname,
            string nachname,
            string familienStand,
            double monatsEinkommen,
            double wohnKosten,
            double einkuenfteAlimente,
            double ausgabenAlimente,
            double ratenZahlungen)
        {
            Debug.WriteLine("KreditFreigabe - FreigabeErteilt");
            Debug.Indent();
            bool freigabe = false;

            if (string.IsNullOrEmpty(vorname))
                throw new ArgumentNullException(nameof(vorname));
            if (string.IsNullOrEmpty(nachname))
                throw new ArgumentNullException(nameof(nachname));
            if (monatsEinkommen <= 0 || monatsEinkommen > 1000000)
                throw new ArgumentException($"Ungültigter Wert für {nameof(monatsEinkommen)}");
            if (wohnKosten < 0 || wohnKosten > 200000)
                throw new ArgumentException($"Ungültigter Wert für {nameof(wohnKosten)}");
            if (einkuenfteAlimente < 0 || einkuenfteAlimente > 10000)
                throw new ArgumentException($"Ungültigter Wert für {nameof(einkuenfteAlimente)}");
            if (ausgabenAlimente < 0 || ausgabenAlimente > 10000)
                throw new ArgumentException($"Ungültigter Wert für {nameof(ausgabenAlimente)}");
            if (ratenZahlungen < 0 || ratenZahlungen > 10000)
                throw new ArgumentException($"Ungültigter Wert für {nameof(ratenZahlungen)}");

            double verfügbarerBetrag = monatsEinkommen + einkuenfteAlimente - wohnKosten - einkuenfteAlimente - ausgabenAlimente - ratenZahlungen;
            double verhältnisWohkostenVerfügbarerBetrag = wohnKosten / verfügbarerBetrag;

            switch (familienStand)
            {
                case "ledig":
                case "verwitwet":
                    switch (geschlecht)
                    {
                        case "m":
                            freigabe = verfügbarerBetrag > wohnKosten * 2;
                            break;
                        case "w":
                            freigabe = verfügbarerBetrag > wohnKosten * 1.8;
                            break;
                        default:
                            throw new ArgumentException($"Ungültiger Wert für {nameof(geschlecht)}!\n\nNur 'm' oder 'w' erlaubt.");
                            break;
                    }

                    break;
                case "in Partnerschaft":
                case "verheiratet":
                    if (verhältnisWohkostenVerfügbarerBetrag < 0.5)
                    {
                        freigabe = verfügbarerBetrag > wohnKosten * 2.5;
                    }
                    else
                    {
                        freigabe = verfügbarerBetrag > wohnKosten * 3.5;
                    }
                    break;
                default:
                    throw new ArgumentException($"Ungültiger Wert für {nameof(familienStand)}!\n\nNur 'ledig', 'verwitwet', 'in Partnerschaft', 'verheiratet' erlaubt.");
                    break;
            }

            Debug.Unindent();
            return freigabe;
        }
    }
}
