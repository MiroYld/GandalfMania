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
            Carte stade = new Carte(20, 70);
            stade.Ennemis.Add(new Personnage("l'orque", "Monstre", 5, 2, 1, 2, 15, 18));
            stade.Ennemis.Add(new Personnage("l'orque", "Monstre", 5, 2, 1, 2, 19, 66));
            stade.Ennemis.Add(new Personnage("l'archer", "Monstre", 5, 2, 1, 2, 3, 44));
            stade.Ennemis.Add(new Personnage("le Gobelin", "Monstre", 5, 2, 1, 2, 6, 55));
            stade.Ennemis.Add(new Personnage("le Gobelin", "Monstre", 5, 2, 1, 2, 12, 24));

            stade.Objets.Add(new Objet("Alcool", "PV", 10, 10, 10));
            stade.Objets.Add(new Objet("Dague Elfique", "Force", 10, 15, 50));
            stade.Objets.Add(new Objet("Potion", "Force", 5, 2, 2));
            stade.Objets.Add(new Objet("le précieux", "Force", 100, 40, 78));

            Console.Clear();

            Console.WriteLine("Bienvenue aventurier, quel est ton nom ?");
            string Nom = Console.ReadLine();

            Console.WriteLine("Choisi ton camp "+Nom+" ? 1=Mage 2=Humain 3=Elfe 4=Hobbit");
            switch (Console.ReadLine())
            {
                case "1":
                    stade.Heros = new Joueur(Nom, "Mage", 150, 10, 10, 1, 5, 5);
                    break;
                case "2":
                    stade.Heros = new Joueur(Nom, "Humain", 100, 7, 7, 5, 5, 5);
                    break;
                case "3":
                    stade.Heros = new Joueur(Nom, "Elfe", 75, 10, 5, 10, 5, 5);
                    break;
                default:
                    stade.Heros = new Joueur(Nom, "Hobbit", 25, 1, 1, 1, 5, 5);
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
