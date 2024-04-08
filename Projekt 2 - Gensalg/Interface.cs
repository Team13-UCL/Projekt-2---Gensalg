using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_2___Gensalg
{
    internal class Interface
    {

        public void visSpilOversigt()
        {

        }
        public void searchForGames()
        {

        }

        private int chosenFunction; // brugerens valg i menuen registreres i denne int
        private string menuTitle = "Menu for lagersystemet"; // menutitel
        private string askUserChoice = "\n\n\tVælg hvilken funktion, du ønsker at benytte og tryk enter"; // besked til brugeren, når menuen starter
        private string[] menuItems = { "1. Vis/Print lagerliste", "2. Søg efter spil", "3. Vis liste over forespørgsler", "4. Opret spil", "5. Rediger spil", "6. Slet spil", "7. Opret forespørgsel", "8. Afslut Program\n" }; // denne array indeholder menupunkterne

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\t" + menuTitle);

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine("\n\t" + menuItems[i]);
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
                else if (chosenFunction < 1 || chosenFunction > 8) // tjekker om bruger input er et tal uden for menuen
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
