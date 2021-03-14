using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace possible_vulnerabilities
{
    class Scanner
    {
        private readonly String URL;
        private readonly List<IVulnerability> vulnerabilitiesClasses;
        public Scanner(String URL, List<IVulnerability> vulnerabilitiesClasses)
        {
            this.URL = URL;
            this.vulnerabilitiesClasses = vulnerabilitiesClasses;
        }

        public void Scan()
        {
            // <{Vuln name},{Vuln details ref}>
            SortedList<String, String> vulnsCheck = new SortedList<String, String>();

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Scanning for Possible Vulnerabilities.....");

            ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < vulnerabilitiesClasses.Count; i++)
            {
                IVulnerability vulnerability = vulnerabilitiesClasses[i];
                WriteLine("Checking {0}...", vulnerability.Name);

                if (vulnerability.IsItVulnerable())
                {
                    vulnsCheck.Add(vulnerability.Name, vulnerability.RefrenceSite);
                }
            }

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Done!\n================================================================");

            ForegroundColor = ConsoleColor.Red;
            if (vulnsCheck.Count == 0)
            {
                WriteLine("No possible vulnerability is found!");
            }
            else
            {
                foreach (var item in vulnsCheck)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("[{0}]: is possible vulnerability", item.Key);
                    WriteLine("   Check [{0}] for more info about the vulnerability.", item.Value);
                    ForegroundColor = ConsoleColor.Blue;
                }
            }
        }
    }
}
