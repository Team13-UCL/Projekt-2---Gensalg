using System.Reflection;

namespace Projekt_2___Gensalg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool endProgram = false; // bruges til at tjekke om menu-loopet skal stoppe og programmet afsluttes

            Interface menu = new Interface();            

            Game game = new Game();

            Request request = new Request();

            
            while (endProgram == false)
            {
                menu.ShowMenu(); // viser menuen

                menu.RegisterChoice(); // registrerer brugerens menuvalg

                Console.Clear();

                switch (menu.GetChosenFunction()) // henter brugerens menuvalg og aktiverer menuvalget
                {
                    case 1:
                        game.ShowInventory(); // Viser bare vores Lager liste
                        break;
                    case 2:
                        game.SearchForGame(); // Søger efter det søgte navn på vores lagerliste
                        break;
                    case 3:
                        game.AddGame(); // Tilføjer spillet til lageroversigten                            
                        break;                        
                    case 4:
                        game.EditGame();
                        break;                        
                    case 5:
                        game.DeleteGame();
                        break;
                    case 6:
                        request.ShowRequests(); // Viser listen over forespørgelserne
                        break;
                    case 7:
                        request.SearchForRequest();
                        break;                        
                    case 8:
                        request.CreateRequest(); // tilføjer vores forespørgsel til vores lager 
                        break;
                    case 9:
                        request.EditRequest();
                        break;
                    case 10:
                        request.DeleteRequest();
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
