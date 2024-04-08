using System.Reflection;

namespace Projekt_2___Gensalg
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //her skal selve programmet køres igennem

            // ** TILFØJET HERFRA - CLA

            Lageroversigt lageroversigt = new Lageroversigt();

            bool endProgram = false; // bruges til at tjekke om menu-loopet skal stoppe og programmet afsluttes

            Interface menu = new Interface();

            
            while (endProgram == false)
            {


                menu.ShowMenu(); // viser menuen

                menu.RegisterChoice(); // registrerer brugerens menuvalg

                Console.Clear();

                switch (menu.GetChosenFunction()) // aktiverer brugerens menuvalg
                {
                    case 1:
                        Console.WriteLine("Her er lagerlisten");
                        lageroversigt.VisLageroversigt(); // Viser bare vores Lager liste
                        break;
                    case 2:
                        Console.WriteLine("Her kan du søge efter et spil");
                        string søgning = Console.ReadLine(); 
                        lageroversigt.SøgEfterSpil(søgning); // Søger efter det søgte navn på vores lagerliste
                        break;
                    case 3:
                        Console.WriteLine("Her er listen over forespørgsler");
                        lageroversigt.VisForespoergsler(); // Viser listen over forespørgelserne
                        break;
                    case 4:
                        Console.WriteLine("Her er kan du oprette et spil");
                        string spilNavn = Console.ReadLine();
                        Spil nytSpil = new Spil { Navn = spilNavn }; // Opretter et nyt med navnet
                        lageroversigt.TilføjSpil(nytSpil); // Tilføjer spillet til lageroversigten
                        Console.WriteLine($"Spillet '{spilNavn}' er blevet tilføjet til lageroversigten.");
                        break;
                    case 5:
                        Console.WriteLine("Her kan du oprette en forespørgsel");
                        string ForespørgselNavn = Console.ReadLine(); // Opretter en ny forespørgsel
                        lageroversigt.Opretforespørgsel(ForespørgselNavn); // tilføjer vores forespørgsel til vores lager 
                        break;
                    case 6:
                        {
                            Console.WriteLine("Gem Data");

                            GemFilerne gemFilerne = new GemFilerne();

                            string txtPath = AppDomain.CurrentDomain.BaseDirectory + "data.txt";
                            // Gemmer dataen
                            List<Spil> dataAtGemme = new List<Spil>();

                            dataAtGemme = lageroversigt.RetunerListe();

                            gemFilerne.GemData(dataAtGemme, txtPath);

                        }
                        break;
                    case 7:
                        Console.WriteLine("Nu afsluttes programmet");
                        endProgram = true;
                        break;
                    case 8:
                        {
                            GemFilerne gemFilerne = new GemFilerne();

                            string txtPath = AppDomain.CurrentDomain.BaseDirectory + "data.txt";
                            // Indlæser vores data håber jeg. Prøver lige og bruge data.txt. først
                            List<string> indlæsteData = gemFilerne.IndlæsData(txtPath);

                            // Gør noget med de indlæste data, f.eks. udskriv dem
                            foreach (var element in indlæsteData)
                            {
                                lageroversigt.TilføjSpil(new Spil { Navn = element });
                            }
                        }
                        break;
                }

                                
                Console.WriteLine("\nTryk enter for at fortsætte"); 
                Console.ReadLine();
                Console.Clear();
            }

            // HERTIL - CLA ***

            /* Console.WriteLine("Hello, World!");
            Console.WriteLine("Hej gruppe 13 :D");
            Console.WriteLine("Jeg har fucked det op");
            Console.ReadLine();*/
        }
    }
}
