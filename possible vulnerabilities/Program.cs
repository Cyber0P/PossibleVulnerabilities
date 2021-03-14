using System;
using System.Collections.Generic;
using System.Net;
using static System.Console;

namespace possible_vulnerabilities
{
    class Program
    {
        static void Main(String[] args)
        {
            Start();
            CheckArguments(args);
        }

        private static void Start()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(@"______             _ _     _        _   _       _                      _     _ _ _ _   _           
| ___ \           (_) |   | |      | | | |     | |                    | |   (_) (_) | (_)          
| |_/ /__  ___ ___ _| |__ | | ___  | | | |_   _| |_ __   ___ _ __ __ _| |__  _| |_| |_ _  ___  ___ 
|  __/ _ \/ __/ __| | '_ \| |/ _ \ | | | | | | | | '_ \ / _ \ '__/ _` | '_ \| | | | __| |/ _ \/ __|
| | | (_) \__ \__ \ | |_) | |  __/ \ \_/ / |_| | | | | |  __/ | | (_| | |_) | | | | |_| |  __/\__ \
\_|  \___/|___/___/_|_.__/|_|\___|  \___/ \__,_|_|_| |_|\___|_|  \__,_|_.__/|_|_|_|\__|_|\___||___/
                                                                                                   
                                                                                                   ");
        }
        private static void CheckArguments(String[] args)
        {
            if (args.Length > 0)
            {
                String arg = args[0];
                if (arg == "help")
                {
                    Help();
                }
                else if (arg.Contains("www") && (arg.Contains("https") || arg.Contains("http")))
                {
                    if (CheckURLStatus(arg))
                    {
                        Scan(arg);
                    }
                }
            }
            else
            {
                Help();
            }
        }

        private static void Scan(String url)
        {
            Scanner scanner = new Scanner(url, InitVulenrabilites(url)); ;
            scanner.Scan();
        }

        private static List<IVulnerability> InitVulenrabilites(String URL)
        {
            List<IVulnerability> vulnerabilitiesClasses = new List<IVulnerability>
            {
                new HTTP_request_smuggling(URL)
            };
            return vulnerabilitiesClasses;
        }

        private static void Help()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("The commands are:-");
        }

        private static Boolean CheckURLStatus(String url)
        {
            try
            {
                HttpStatusCode status = ((HttpWebResponse)((HttpWebRequest)WebRequest.Create(url)).GetResponse()).StatusCode;
                if (status == HttpStatusCode.OK)
                    return true;
            }
            catch (WebException e)
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\r\nWebException Raised. The following error occurred : {0}", e.Status);
            }
            catch (Exception e)
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
            }
            return false;
        }

    }
}

