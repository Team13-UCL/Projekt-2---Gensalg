using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_2___Gensalg
{
    public class Request
    {
        public void CreateRequestList() // opretter en fil til lagerlisten 
        {
            Console.WriteLine("Forespørgselslisten er tom\n\n");

            using (StreamWriter outputFile = new StreamWriter("RequestList.txt"))
            {
                // linjen med using sørger for at der oprettes en tom tekstfil med filnavnet
            }
        }

        public void CreateRequest()
        {
            if (!File.Exists("RequestList.txt")) // Tjekker om der er oprettet en fil til forespørgselslisten, og opretter filen hvis den ikke findes i forvejen
            {
                CreateRequestList();
            }

            string[] lines = File.ReadAllLines("RequestList.txt"); // indlæser data fra lagerlistefilen til et array

            Console.WriteLine("Indtast en ny forespørgsel med følgende informationer:\n\nKundenavn, Kunde tlf., Kunde email, Spilnavn");
            string myString = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter("RequestList.txt")) // skriver de tidligere indlæste data fra arrayet samt ny data (tilføjet forespørgsel) til forespørgselslistefilen
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine(line);
                }
                outputFile.WriteLine(myString);
            }

            Console.WriteLine($"\n\nForespørgslen '{myString}' er blevet tilføjet til listen over forespørgsler.\n");
        }


        public void EditRequest()
        {
            List<string> lines = new List<string>(File.ReadAllLines("RequestList.txt")); // der oprettes en liste som indlæser indhold i forespørgsel tekstfilen til listen
            List<string> foundLines = new List<string>(); // denne liste bruges til at gemme linjer der indeholder søgeordet
            int j = 0; // bruges til at give et nummer til hver af de linjer der indeholder søgeordet
            bool anyElementFound = false; // fortæller om søgningen har givet nogen resultater
            bool correctChoice = false; // sikrer, at brugeren træffer et acceptabelt valg

            Console.WriteLine("Skriv navnet på den forespørgsel, du ønsker at redigere");
            string searchWord = Console.ReadLine();

            Console.WriteLine("\n\nHer er de forespørgsler, der indeholder din indtastning:\n");

            for (int i = 0; i < lines.Count; i++) // søger gennem de indlæste linjer fra forespørgselslistefilen og gemmer de linjer, der indeholder søgeordet, i foundLines listen
            {
                if (lines[i].Contains(searchWord, StringComparison.OrdinalIgnoreCase)) // OrdinalIgnoreCase sørger for at ignorere forskel på små og store bogstaver
                {
                    j++;
                    Console.WriteLine(j + "\t" + lines[i] + "\n");
                    anyElementFound = true;
                    foundLines.Add(lines[i]);
                }
            }
            Console.WriteLine("\n(tryk 0 for hovedmenuen)\n");

            while (!correctChoice) // gentages, indtil brugeren træffer et acceptabelt valg
            {
                if (!anyElementFound) // tjekker, om søgningen ikke har givet nogen resultater
                {
                    Console.WriteLine("Der er ingen forespørgsler, der indeholder din indtastning\n\n");
                    break;
                }
                else // udføres hvis søgningen har givet resultater
                {
                    Console.WriteLine("\nSkriv tallet ud for den forespørgsel, du ønsker at redigere");
                    if (!int.TryParse(Console.ReadLine(), out j)) // denne if blok tjekker, om brugeren træffer et acceptabelt valg
                    {
                        Console.WriteLine("\n\nDu har tastet forkert");
                    }
                    else if (j > foundLines.Count || j < 0)
                    {
                        Console.WriteLine("\n\nDu har valgt et tal, der ikke er i menuen");
                    }
                    else // udføres hvis brugeren har truffet et acceptabelt valg
                    {
                        if (j == 0) // tjekker om brugeren har tastet 0 for hovedmenuen og breaker, hvis det er tilfældet
                        {
                            break;
                        }

                        Console.WriteLine("\n\nDu har valgt linjen:\n" + foundLines[j - 1]);

                        for (int i = 0; i < lines.Count; i++) // sammenligner den linje brugeren har valgt at redigere med alle linjer i lines listen for at finde den, der skal erstattes
                        {
                            if (lines[i].Contains(foundLines[j - 1], StringComparison.OrdinalIgnoreCase)) // OrdinalIgnoreCase sørger for at ignorere forskel på små og store bogstaver
                            {
                                Console.WriteLine("\n\n\nIndtast forespørgslens opdaterede informationer::\n\nKundenavn, Kunde tlf., Kunde email, Spilnavn");
                                lines[i] = Console.ReadLine(); // erstatter den valgte linje med det brugeren indtaster

                                using (StreamWriter outputFile = new StreamWriter("RequestList.txt")) // skriver de opdaterede linjer i listen lines til forespørgselslistefilen
                                {
                                    foreach (string line in lines)
                                    {
                                        outputFile.WriteLine(line);
                                    }

                                }

                                Console.WriteLine($"\nForespørgslen '{lines[i]}' er blevet opdateret.");
                                correctChoice = true; // bekræfter at brugeren har truffet et acceptabelt valg, så loopet kan stoppe
                            }
                        }
                    }
                }
            }
        }

        public void DeleteRequest()
        {
            List<string> lines = new List<string>(File.ReadAllLines("RequestList.txt")); // der oprettes en liste som indlæser indhold i forespørgsel tekstfilen til listen
            List<string> foundLines = new List<string>(); // denne liste bruges til at gemme linjer der indeholder søgeordet
            int j = 0; // bruges til at give et nummer til hver af de linjer der indeholder søgeordet
            bool anyElementFound = false; // fortæller om søgningen har givet nogen resultater
            bool correctChoice = false; // sikrer, at brugeren træffer et acceptabelt valg 


            Console.WriteLine("Skriv navnet på den forespørgsel, du ønsker at slette");
            string searchWord = Console.ReadLine();

            Console.WriteLine("\n\nHer er de forespørgsler, der indeholder din indtastning:\n");

            for (int i = 0; i < lines.Count; i++) // søger gennem de indlæste linjer fra forespørgselslistefilen og gemmer de linjer, der indeholder søgeordet, i foundLines listen
            {
                if (lines[i].Contains(searchWord, StringComparison.OrdinalIgnoreCase)) // OrdinalIgnoreCase sørger for at ignorere forskel på små og store bogstaver
                {
                    j++;
                    Console.WriteLine(j + "\t" + lines[i] + "\n");
                    anyElementFound = true;
                    foundLines.Add(lines[i]);
                }
            }
            Console.WriteLine("\n(tryk 0 for hovedmenuen)\n");

            while (!correctChoice) // gentages, indtil brugeren træffer et acceptabelt valg
            {
                if (!anyElementFound) // tjekker, om søgningen ikke har givet nogen resultater
                {
                    Console.WriteLine("Der er ingen forespørgsler, der indeholder din indtastning\n\n");
                    break;
                }
                else // udføres hvis søgningen har givet resultater
                {
                    Console.WriteLine("\nSkriv tallet ud for den forespørgsel, du ønsker at slette");

                    if (!int.TryParse(Console.ReadLine(), out j)) // denne if blok tjekker, om brugeren træffer et acceptabelt valg
                    {
                        Console.WriteLine("\n\nDu har tastet forkert");
                    }
                    else if (j > foundLines.Count || j < 0)
                    {
                        Console.WriteLine("\n\nDu har valgt et tal, der ikke er i menuen");
                    }
                    else // udføres hvis brugeren har truffet et acceptabelt valg
                    {
                        if (j == 0) // tjekker om brugeren har tastet 0 for hovedmenuen og breaker, hvis det er tilfældet
                        {
                            break;
                        }

                        Console.WriteLine("\n\nDu har valgt linjen:\n" + foundLines[j - 1]);

                        for (int i = 0; i < lines.Count; i++) // sammenligner den linje brugeren har valgt at redigere med alle linjer i lines listen for at finde den, der skal slettes
                        {
                            if (lines[i].Contains(foundLines[j - 1], StringComparison.OrdinalIgnoreCase)) // OrdinalIgnoreCase sørger for at ignorere forskel på små og store bogstaver
                            {
                                string deletedRequest = lines[i];
                                lines.Remove(lines[i]); // sletter den linje brugeren har valgt fra lines listen

                                using (StreamWriter outputFile = new StreamWriter("RequestList.txt")) // skriver de resterende linjer i listen lines til forespørgselslistefilen
                                {
                                    foreach (string line in lines)
                                    {
                                        outputFile.WriteLine(line);
                                    }

                                }

                                Console.WriteLine($"\nForespørgslen '{deletedRequest}' er blevet slettet.");
                                correctChoice = true; // bekræfter at brugeren har truffet et acceptabelt valg, så loopet kan stoppe
                            }
                        }
                    }
                }
            }
        }

        public void ShowRequests()
        {
            if (!File.Exists("RequestList.txt")) // tjekker om forespørgselslistefilen eksisterer og opretter den hvis ikke den eksisterer, samt giver brugeren besked om at listen er tom
            {
                CreateRequestList();
            }
            else
            {
                string[] lines = File.ReadAllLines("RequestList.txt"); // indlæser data fra forespørgselslistefilen til et array

                if (lines.Length == 0) // tjekker om forespørgselslisten er tom og giver besked til brugeren
                {
                    Console.WriteLine("Forespørgselslisten er tom");
                }
                else
                {
                    // Udskriv alle linjerne i forespørgselslisten til konsolvinduet 
                    Console.WriteLine("Her er listen over forespørgsler\n\n");
                    foreach (string line in lines) // udskriver arrayet med indholdet fra forespørgselslistefilen til konsolvinduet
                    {
                        Console.WriteLine(line + "\n");
                    }
                }
            }
        }


        public void SearchForRequest()
        {
            if (!File.Exists("RequestList.txt")) // tjekker om forespørgselslistefilen ikke eksisterer endnu og opretter den
            {
                CreateRequestList();
            }
            else // starter søgefunktion hvis forespørgselslistefilen eksisterer
            {
                List<string> lines = new List<string>(File.ReadAllLines("RequestList.txt")); // opretter en liste som indlæser indhold i forespørgsel tekstfilen til listen

                Console.WriteLine("Indtast søgeord");
                string searchWord = Console.ReadLine();
                bool anyElementFound = false; // fortæller om søgningen har givet nogen resultater

                Console.WriteLine("\n\nHer er søgeresultaterne:\n");
                for (int i = 0; i < lines.Count; i++) // søger gennem de indlæste linjer fra forespørgselslistefilen og udskriver de linjer, der indeholder søgeordet, til konsolvinduet
                {
                    if (lines[i].Contains(searchWord, StringComparison.OrdinalIgnoreCase)) // OrdinalIgnoreCase sørger for, at den ignorerer forskel på små og store bogstaver
                    {
                        Console.WriteLine(lines[i] + "\n\n");
                        anyElementFound = true; // giver besked om, at der er matchende søgeresultater
                    }
                }

                if (!anyElementFound) // tjekker om søgningen har givet 0 resultater og giver besked, hvis det er tilfældet
                {
                    Console.WriteLine("Søgningen gav ingen resultater\n\n");
                }
            }
        }

    }

}
