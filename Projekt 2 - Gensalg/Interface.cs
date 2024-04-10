using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_2___Gensalg
{
    internal class Interface
    {
        private int chosenFunction; // brugerens valg i menuen registreres i denne int
        private string menuTitle = "Menu for lagersystemet"; // menutitel
        private string askUserChoice = "\n\n\tVælg hvilken funktion, du ønsker at benytte og tryk enter"; // besked til brugeren, når menuen starter
        private string[] menuItems = { "1. Vis/Print lagerliste", "6. Vis liste over forespørgsler", "2. Søg efter spil", "\t 7. Søg efter forespørgsel", "3. Opret spil", "\t\t 8. Opret forespørgsel", "4. Rediger spil", "\t 9. Rediger forespørgsel", "5. Slet spil", "\t\t10. Slet forespørgsel", "11. Afslut Program\n" }; // denne array indeholder menupunkterne
        
        
        public void ShowMenu()
        {
            
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkYellow;

            Console.Clear();
            
            Console.WriteLine("\t\t\t" + menuTitle);

            for (int i = 0; i < menuItems.Length; i += 2) 
            {
                if (i < menuItems.Length - 1) // for at den ikke komme udenfor arrayen
                    Console.WriteLine($"{menuItems[i]} \t\t\t {menuItems[i + 1]}");
                else
                    Console.WriteLine($"\t\t\t{menuItems[10]}");
            }


            Console.WriteLine(askUserChoice);
        }

        
        public void RegisterChoice()
        {
            bool correctChoice = false;
            while (!correctChoice) // Tjekker om bruger har indtastet et gyldigt tal og fortsætter med at spørge indtil der vælges et gyldigt tal
            {
                if (!int.TryParse(Console.ReadLine(), out chosenFunction)) // tjekker om brugers input er andet end et tal og konverterer input string til int hvis input er et tal
                {
                    WrongChoice();
                }
                else if (chosenFunction < 1 || chosenFunction > 11) // tjekker om bruger input er et tal uden for menuen
                {
                    WrongChoice();
                }
                else { correctChoice = true; } // hvis de 2 forrige conditions er false, er brugerens input korrekt, og dette stopper loopet
            }
        }


        public void WrongChoice() // fejlbesked til brugeren og genstart af menuen i tilfælde af forkert intastning
        {
            Console.WriteLine("\nForkert indtastning. Du skal vælge et tal fra menuen. \n\nTryk på en vilkårlig tast for at fortsætte.");
            Console.ReadKey();
            Console.Clear();
            ShowMenu();
        }

        
        public int GetChosenFunction() // returnerer brugerens input
        {
            return chosenFunction;
        }
    }
}
