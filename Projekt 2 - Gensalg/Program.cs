namespace Projekt_2___Gensalg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //her skal selve programmet køres igennem

            // ** TILFØJET HERFRA - CLA

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
                        break;
                    case 2:
                        Console.WriteLine("Her kan du søge efter et spil");
                        break;
                    case 3:
                        Console.WriteLine("Her er listen over forespørgsler");                        
                        break;
                    case 4:
                        Console.WriteLine("Her er kan du oprette et spil");
                        break;
                    case 5:
                        Console.WriteLine("Her kan du oprette en forespørgsel");
                        break;
                    case 6:
                        Console.WriteLine("Nu afsluttes programmet");
                        endProgram = true;
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
