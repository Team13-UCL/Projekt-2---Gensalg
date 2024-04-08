using System.Reflection;

namespace Projekt_2___Gensalg
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool endProgram = false; // bruges til at tjekke om menu-loopet skal stoppe og programmet afsluttes

            Interface menu = new Interface();

            Lageroversigt lageroversigt = new Lageroversigt();

            

            while (endProgram == false)
            {
                menu.ShowMenu(); // viser menuen

                menu.RegisterChoice(); // registrerer brugerens menuvalg

                Console.Clear();

                switch (menu.GetChosenFunction()) // henter brugerens menuvalg og aktiverer menuvalget
                {
                    case 1:
                        lageroversigt.VisLageroversigt(); // Viser bare vores Lager liste
                        break;
                    case 2:
                        lageroversigt.SøgEfterSpil(); // Søger efter det søgte navn på vores lagerliste
                        break;
                    case 3:
                        lageroversigt.TilføjSpil(); // Tilføjer spillet til lageroversigten                            
                        break;                        
                    case 4:
                        lageroversigt.EditGame();
                        break;                        
                    case 5:
                        lageroversigt.DeleteGame();
                        break;
                    case 6:
                        lageroversigt.VisForespoergsler(); // Viser listen over forespørgelserne
                        break;
                    case 7:
                        lageroversigt.SearchForRequest();
                        break;                        
                    case 8:
                        lageroversigt.Opretforespørgsel(); // tilføjer vores forespørgsel til vores lager 
                        break;
                    case 9:
                        lageroversigt.EditRequest();
                        break;
                    case 10:
                        lageroversigt.DeleteRequest();
                        break;
                    case 11:
                        Console.WriteLine("Nu afsluttes programmet");
                        endProgram = true;
                        break;
                }

                Console.WriteLine("\nTryk enter for at fortsætte");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
