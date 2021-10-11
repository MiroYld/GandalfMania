using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Carte stade =  new Carte(20, 70);
            stade.Ennemis.Add(new Personnage("Gobelin", "Monstre", 5, 2, 1, 2, 15, 18));
            stade.Ennemis.Add(new Personnage("Gobelin", "Monstre", 5, 2, 1, 2, 19, 66));
            stade.Ennemis.Add(new Personnage("Gobelin", "Monstre", 5, 2, 1, 2, 3, 44));
            stade.Ennemis.Add(new Personnage("Gobelin", "Monstre", 5, 2, 1, 2, 6, 55));
            stade.Ennemis.Add(new Personnage("Gobelin", "Monstre", 5, 2, 1, 2, 12, 24));

            Console.Clear();

            Console.WriteLine("Bienvenue aventurier, quel est ton nom ?");
            string Nom = Console.ReadLine();

            Console.WriteLine("Quelles sont vos compétences ? 1=Guerrier 2=Ranger 3=Voleur");
            switch (Console.ReadLine())
            {
                case "1":
                    stade.Heros = new Personnage(Nom, "Guerrier", 150, 10, 10, 1, 5, 5);
                    break;
                case "2":
                    stade.Heros = new Personnage(Nom, "Ranger", 100, 7, 7, 5, 5, 5);
                    break;
                case "3":
                    stade.Heros = new Personnage(Nom, "Voleur", 75, 10, 5, 10, 5, 5);
                    break;
                default:
                    stade.Heros = new Personnage(Nom, "Vagabond", 25, 1, 1, 1, 5, 5);
                    break;
            }
            while (stade.Heros.PV > 0)
            {
                stade.AfficherCarte();

                stade.Deplacement();

                stade.Contact();
            }
            Console.WriteLine("GAME OVER");
            Console.ReadLine();
        }
    }
}
