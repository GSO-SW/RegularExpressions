using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressions
{
    class Program
    {
        #region Regular Expressions

        // Konstante globale Variablen
        const string RA_GUID = @"\{[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9|a-f|A-F]{12}\}";
        const string RA_IPAdresse = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
        const string RA_Email = @"^(?<user>[^@]+)@(?<host>.+)$";
        const string RA_Datum_EN_US = @"\b(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})\b";

        #endregion

        static void Main(string[] args)
        {
            // Testdaten
            string eingabe1 = @"{00000615-0000-0010-8000-00AA006D2EA4}"; // Globally Unique Identifier (GUID) -> korrekt
            string eingabe2 = @"192.168.123.355"; // IP -> falsch
            string eingabe3 = @"hs@IT-Visions.de"; // e-mail -> korrekt
            string eingabe4 = @"08/01/1972";

            // Prüfe auf korrektes Format in Unterprogramm
            TestForGUID(eingabe1);
            TestForIP(eingabe2);
            TestForEmail(eingabe3);
            ReplaceUsDateByDeDate(eingabe4);

            // Hält die Konsole offen
            Console.ReadLine();
        }

        /// <summary>
        /// Überführt das angegebene Datum im amerikanischen Format in das korrekte deutsche Format.
        /// </summary>
        /// <param name="eingabe4">Ein Datum im amerikanischen Format (en-us).</param>
        private static void ReplaceUsDateByDeDate(string eingabe4)
        {
            // Deutsches Format für ein Datum
            const string RA_Datum_DE_DE = @"${day}.${month}.${year}";

            Console.WriteLine("Datum EN-US: " + eingabe4);
            Console.WriteLine("Datum DE-DE: " + Regex.Replace(eingabe4, RA_Datum_EN_US, RA_Datum_DE_DE));
        }

        /// <summary>
        /// Prüft ob der übergebene Parameter eine E-Mail ist.
        /// </summary>
        /// <param name="testString">Der zu überprüfende Parameter.</param>
        private static void TestForEmail(string testString)
        {
            Console.WriteLine($"E-Mail-Adresse {testString} korrekt? " + Regex.IsMatch(testString, RA_Email));
        }

        /// <summary>
        /// Prüft ob der übergebene Parameter eine IP-Adresse ist.
        /// </summary>
        /// <param name="testString">Der zu überprüfende Parameter.</param>
        private static void TestForIP(string testString)
        {
            Console.WriteLine($"IP-Adresse {testString} korrekt? " + Regex.IsMatch(testString, RA_IPAdresse));
        }

        /// <summary>
        /// Prüft ob der übergebene Parameter eine GUID ist.
        /// </summary>
        /// <param name="testString">Der zu überprüfende Parameter.</param>
        private static void TestForGUID(string testString)
        {
            Console.WriteLine($"GUID {testString} korrekt? " + Regex.IsMatch(testString, RA_GUID));
        }
    }
}
