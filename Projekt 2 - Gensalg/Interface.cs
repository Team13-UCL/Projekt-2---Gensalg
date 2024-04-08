using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Projekt_2___Gensalg
{
    internal class Lageroversigt
    {
        private List<Spil> spilILager; // En liste over spil i lageret - ** bruges ikke længere, slettes?
        private List<string> Forespørgsel = new List<string>(); // - ** bruges ikke længere, slettes?



        public Lageroversigt() // - ** bruges ikke længere, slettes?
        {
            spilILager = new List<Spil>(); // Initialiserer listen over spil i lageret

        }
        // Metoder til at håndtere lageroversigten

        public void CreateInventoryOrRequestList(string fileName) // opretter en fil til lagerlisten ***** VIRKER
        {
            string listName = "";
            if (fileName == "InventoryList.txt")
            {
                listName = "Lagerlisten";
            }
            else
            {
                listName = "Forespørgselslisten";
            }

            Console.WriteLine(listName + " er tom\n\n");

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                // linjen med using sørger for at der oprettes en tom tekstfil med filnavnet
            }
        }

        public void TilføjSpil() // ***** VIRKER
        {
            if (!File.Exists("InventoryList.txt")) // Tjekker om der er oprettet en fil til lagerlisten, og opretter filen hvis den ikke findes i forvejen
            {
                CreateInventoryOrRequestList("InventoryList.txt");
            }

            string[] lines = File.ReadAllLines("InventoryList.txt"); // indlæser data fra lagerlistefilen til et array

            Console.WriteLine("Indtast et nyt spil med følgende informationer:\n\nSpilnavn, Spilversion, Spilgenre, Antal spillere, Spillets stand, Pris, Lagerantal");
            string myString = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter("InventoryList.txt")) // skriver de tidligere indlæste data fra arrayet samt ny data (tilføjet spil) til lagerlistefilen
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine(line);
                }
                outputFile.WriteLine(myString);
            }
            Console.WriteLine($"\nSpillet '{myString}' er blevet tilføjet til lageroversigten.");
        }

        public void EditGame()
        {
            List<string> lines = new List<string>(File.ReadAllLines("InventoryList.txt")); // der oprettes en liste som indlæser indhold i lager tekstfilen til listen
            List<string> foundLines = new List<string>(); // denne liste bruges til at gemme linjer der indeholder søgeord
            int j = 0; // bruges til at give et nummer til hver af de linjer der indeholder søgeordet
            bool anyElementFound = false; // fortæller om søgningen har givet nogen resultater
            bool correctChoice = false; // sikrer at brugeren træffer et acceptabelt valg

            Console.WriteLine("Skriv navnet på det spil du ønsker at redigere");
            string searchWord = Console.ReadLine();

            Console.WriteLine("\n\nHer er de spil der indeholder din indtastning:\n");

            for (int i = 0; i < lines.Count; i++) // søger gennem de indlæste linjer fra lagerlistefilen og gemmer de linjer der indeholder søgeordet i foundLines listen
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

            while (!correctChoice) // gentages indtil brugeren træffer et acceptabelt valg
            {
                if (!anyElementFound) // tjekker om søgningen ikke har givet nogen resultater
                {
                    Console.WriteLine("Der er ingen spil, der indeholder din indtastning\n\n");
                    break;
                }
                else // udføres hvis søgningen har givet resultater
                {
                    Console.WriteLine("\nSkriv tallet ud for det spil, du ønsker at redigere");
                    if (!int.TryParse(Console.ReadLine(), out j)) // denne if blok tjekker om brugeren træffer et acceptabelt valg
                    {
                        Console.WriteLine("\n\nDu har tastet forkert");
                    }
                    else if (j > foundLines.Count || j < 0)
                    {
                        Console.WriteLine("\n\nDu har valgt et tal der ikke er i menuen");
                    }
                    else // udføres hvis brugeren har truffet et acceptabelt valg
                    {
                        if (j == 0) // tjekker om brugeren har tastet 0 for hovedmenuen og breaker hvis det er tilfældet
                        {
                            break;
                        }

                        Console.WriteLine("\n\nDu har valgt linjen:\n" + foundLines[j - 1]);

                        for (int i = 0; i < lines.Count; i++) // sammenligner den linje brugeren har valgt at redigere med alle linjer i lines listen for at finde den, der skal erstattes
                        {
                            if (lines[i].Contains(foundLines[j - 1], StringComparison.OrdinalIgnoreCase)) // OrdinalIgnoreCase sørger for at ignorere forskel på små og store bogstaver
                            {
                                Console.WriteLine("\n\n\nIndtast spillets opdaterede informationer:\n\nSpilnavn, Spilversion, Spilgenre, Antal spillere, Spillets stand, Pris, Lagerantal");
                                lines[i] = Console.ReadLine(); // erstatter den valgte linje med det brugeren indtaster

                                using (StreamWriter outputFile = new StreamWriter("InventoryList.txt")) // skriver de opdaterede linjer i listen lines til lagerlistefilen
                                {
                                    foreach (string line in lines)
                                    {
                                        outputFile.WriteLine(line);
                                    }

                                }
                                Console.WriteLine($"\nSpillet '{lines[i]}' er blevet opdateret.");
                                correctChoice = true; // bekræfter at brugeren har truffet et acceptabelt valg, så loopet kan stoppe
                            }
                        }
                    }
                }
            }
        }

        public void DeleteGame()
        {
            List<string> lines = new List<string>(File.ReadAllLines("InventoryList.txt")); // der oprettes en liste som indlæser indhold i lager tekstfilen til listen
            List<string> foundLines = new List<string>(); // denne liste bruges til at gemme linjer der indeholder søgeord
            int j = 0; // bruges til at give et nummer til hver af de linjer der indeholder søgeordet
            bool anyElementFound = false; // fortæller om søgningen har givet nogen resultater
            bool correctChoice = false; // sikrer at brugeren træffer et acceptabelt valg

            Console.WriteLine("Skriv navnet på det spil du ønsker at slette");
            string searchWord = Console.ReadLine();

            Console.WriteLine("\n\nHer er de spil, der indeholder din indtastning:\n");

            for (int i = 0; i < lines.Count; i++) // søger gennem de indlæste linjer fra lagerlistefilen og gemmer de linjer der indeholder søgeordet i foundLines listen
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

            while (!correctChoice) // gentages indtil brugeren træffer et acceptabelt valg
            {
                if (!anyElementFound) // tjekker om søgningen ikke har givet nogen resultater
                {
                    Console.WriteLine("Der er ingen spil, der indeholder din indtastning\n\n");
                    break;
                }
                else // udføres hvis søgningen har givet resultater
                {
                    Console.WriteLine("\nSkriv tallet ud for det spil, du ønsker at slette");
                    if (!int.TryParse(Console.ReadLine(), out j)) // denne if blok tjekker om brugeren træffer et acceptabelt valg
                    {
                        Console.WriteLine("\n\nDu har tastet forkert");
                    }
                    else if (j > foundLines.Count || j < 0)
                    {
                        Console.WriteLine("\n\nDu har valgt et tal, der ikke er i menuen");
                    }
                    else // udføres hvis brugeren har truffet et acceptabelt valg
                    {
                        if (j == 0) // tjekker om brugeren har tastet 0 for hovedmenuen og breaker hvis det er tilfældet
                        {
                            break;
                        }

                        Console.WriteLine("\n\nDu har valgt linjen:\n" + foundLines[j - 1]);

                        for (int i = 0; i < lines.Count; i++) // sammenligner den linje brugeren har valgt at slette med alle linjer i lines listen for at finde den, der skal slettes
                        {
                            if (lines[i].Contains(foundLines[j - 1], StringComparison.OrdinalIgnoreCase)) // OrdinalIgnoreCase sørger for at ignorere forskel på små og store bogstaver
                            {
                                string deletedGame = lines[i];
                                lines.Remove(lines[i]); // sletter den linje brugeren har valgt fra lines listen

                                using (StreamWriter outputFile = new StreamWriter("InventoryList.txt")) // skriver de resterende linjer i lines listen til lagerlistefilen
                                {
                                    foreach (string line in lines)
                                    {
                                        outputFile.WriteLine(line);
                                    }
                                }
                                Console.WriteLine($"\nSpillet '{deletedGame}' er blevet slettet.");
                                correctChoice = true; // bekræfter at brugeren har truffet et acceptabelt valg, så loopet kan stoppe
                            }
                        }
                    }
                }
            }
        }

        public List<Spil> RetunerListe() // - ** bruges ikke længere, slettes?
        {
            return spilILager;
        }

        public void FjernSpil(Spil spil) // ** bruges ikke
        {
            spilILager.Remove(spil); // Fjern et spil fra lageroversigten
        }
        public void VisLageroversigt() // ***** VIRKER
        {
            if (!File.Exists("InventoryList.txt")) // tjekker om lagerlistefilen eksisterer og opretter den hvis ikke den eksisterer, samt giver brugeren besked om at listen er tom
            {
                CreateInventoryOrRequestList("InventoryList.txt");
            }
            else
            {
                string[] lines = File.ReadAllLines("InventoryList.txt"); // indlæser data fra lagerlistefilen til et array

                if (lines.Length == 0) // tjekker om lagerlisten er tom og giver besked til brugeren
                {
                    Console.WriteLine("Lagerlisten er tom");
                }
                else // viser lagerlisten 
                {
                    Console.WriteLine("Her er lagerlisten:\n\n");
                    // Udskriv alle linjerne i lagerlisten til konsolvinduet 
                    foreach (string line in lines) // udskriver arrayet med indholdet fra lagerlistefilen til konsolvinduet
                    {
                        Console.WriteLine(line + "\n");
                    }
                }
            }
        }


        public void SøgEfterSpil() // ***** VIRKER
        {
            if (!File.Exists("InventoryList.txt")) // tjekker om lagerlistefilen ikke eksisterer endnu og opretter den
            {
                CreateInventoryOrRequestList("InventoryList.txt");
            }
            else // starter søgefunktion hvis lagerlistefilen eksisterer
            {
                List<string> lines = new List<string>(File.ReadAllLines("InventoryList.txt")); // opretter en liste som indlæser indhold i lager tekstfilen til listen

                Console.WriteLine("Indtast søgeord");
                string searchWord = Console.ReadLine();
                bool anyElementFound = false; // fortæller om søgningen har givet nogen resultater

                Console.WriteLine("\n\nHer er søgeresultaterne:\n");
                for (int i = 0; i < lines.Count; i++) // søger gennem de indlæste linjer fra lagerlistefilen og udskriver de linjer der indeholder søgeordet til konsolvinduet
                {
                    if (lines[i].Contains(searchWord, StringComparison.OrdinalIgnoreCase)) // OrdinalIgnoreCase sørger for den ignorer forskel på små og store bogstaver
                    {
                        Console.WriteLine(lines[i] + "\n\n");
                        anyElementFound = true; // giver besked om at der er matchende søgeresultater
                    }
                }

                if (!anyElementFound) // tjekker om søgningen har givet 0 resultater og giver besked hvis det er tilfældet
                {
                    Console.WriteLine("Søgningen gav ingen resultater\n\n");
                }
            }
        }

        public void UdskrivLager() // - ** bruges ikke længere, slettes?
        {
            Console.WriteLine("Lageroversigt:");
            foreach (var spil in spilILager)
            {
                Console.WriteLine(spil.Navn); // Udskriv navnet på hvert spil i lageroversigten
            }
        }

        public void Opretforespørgsel() // ***** VIRKER
        {

            if (!File.Exists("RequestList.txt")) // Tjekker om der er oprettet en fil til forespørgselslisten, og opretter filen hvis den ikke findes i forvejen
            {
                CreateInventoryOrRequestList("RequestList.txt");
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

        public void VisForespoergsler() // ***** VIRKER
        {
            if (!File.Exists("RequestList.txt")) // tjekker om forespørgselslistefilen eksisterer og opretter den hvis ikke den eksisterer, samt giver brugeren besked om at listen er tom
            {
                CreateInventoryOrRequestList("RequestList.txt");
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

                    Console.WriteLine("");
                }
            }
        }

        // Metode til at finde et spil i lageroversigten baseret på navn
        public Spil FindSpil(string navn) // ** ikke nødvendig da der er en anden metode til spil søgning?
        {
            return spilILager.FirstOrDefault(spil => spil.Navn == navn);
        }
    }
}