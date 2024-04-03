using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_2___Gensalg
{
    internal class Lageroversigt
    {
        private List<Spil> spilILager; // En liste over spil i lageret
        private List<string> Forespørgsel = new List<string>();

        public Lageroversigt()
        {
            spilILager = new List<Spil>(); // Initialiserer listen over spil i lageret
        }
        // Metoder til at håndtere lageroversigten
        public void TilføjSpil(Spil spil)
        {
            spilILager.Add(spil); // Tilføj et spil til lageroversigten
        }

        public void FjernSpil(Spil spil)
        {
            spilILager.Remove(spil); // Fjern et spil fra lageroversigten
        }
        public void VisLageroversigt()
        {
            foreach (var spil in spilILager)
            {
                Console.WriteLine(spil.Navn);
            }
            Console.WriteLine("Tryk enter for at fortsætte");
            Console.ReadLine();
        }

        public void SøgEfterSpil(string sogestreng)
        {
            List<Spil> fundneSpil = spilILager.FindAll(spil => spil.Navn.Contains(sogestreng));
            if (fundneSpil.Count > 0)
            {
                Console.WriteLine("Følgende spil blev fundet:");
                foreach (var spil in fundneSpil)
                {
                    Console.WriteLine(spil.Navn);
                }
            }
            else
            {
                Console.WriteLine("Ingen spil blev fundet med det søgeord.");
            }
            Console.WriteLine("Tryk enter for at fortsætte");
            Console.ReadLine();
        }

        public void UdskrivLager()
        {
            Console.WriteLine("Lageroversigt:");
            foreach (var spil in spilILager)
            {
                Console.WriteLine(spil.Navn); // Udskriv navnet på hvert spil i lageroversigten
            }
        }

        public void Opretforespørgsel(string navn)
        {
            Forespørgsel.Add(navn);
            Console.WriteLine("Forespørgslen er blevet oprettet.");
            Console.WriteLine("Tryk enter for at fortsætte");
            Console.ReadLine();
        }
        public void VisForespoergsler()
        {
            Console.WriteLine("Her er alle forespørgslerne:");
            foreach (string forespørgsel in Forespørgsel)
            {
                Console.WriteLine(forespørgsel);
            }
            Console.WriteLine("Tryk enter for at fortsætte");
            Console.ReadLine();
        }

        // Metode til at finde et spil i lageroversigten baseret på navn
        public Spil FindSpil(string navn)
        {
            return spilILager.FirstOrDefault(spil => spil.Navn == navn);
        }
    }
}
