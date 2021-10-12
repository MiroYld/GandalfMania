using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxConsole
{
    class Carte
    {
        public Joueur Heros { get; set; }
        public List<Objet> Objets { get; set; }
        public List<Personnage> Ennemis { get; set; }
        public int Hauteur { get; set; }
        public int Largeur { get; set; }
        public Carte()
        {
            Ennemis = new List<Personnage>();
            Objets = new List<Objet>();
        }

        public Carte(int vHauteur, int vLargeur)
        {
            Ennemis = new List<Personnage>();
            Objets = new List<Objet>();
            Hauteur = vHauteur;
            Largeur = vLargeur;
        }

        public void AfficherCarte()
        {
            Console.Clear();
            string bordure = "";

            for (int j = 0; j < Largeur + 2; j++)
            {
                bordure += "#";
            }
            Console.WriteLine(bordure);

            for (int i = 0; i < Hauteur; i++)
            {
                string carte = "#";
                for (int j = 0; j < Largeur; j++)
                {
                    string contenu = " ";
                    if (i == Heros.PositionX && j == Heros.PositionY)
                    {
                        contenu = "X";
                    }
                    else
                    {
                        foreach (Personnage ennemie in Ennemis)
                        {
                            if (i == ennemie.PositionX && j == ennemie.PositionY)
                            {
                                contenu = "E";
                            }
                        }
                        foreach (Objet item in Objets)
                        {
                            if (i == item.PositionX && j == item.PositionY)
                            {
                                contenu = "O";
                            }
                        }
                    }
                    carte += contenu;
                }

                carte += "#";
                Console.WriteLine(carte);
            }
            Console.WriteLine(bordure);
            Console.WriteLine(Heros.Information);
            Console.WriteLine("Sac:" + Heros.GetContenuSac());
        }

        public void Deplacement()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (Heros.PositionX > 0)
                        Heros.PositionX--;
                    break;
                case ConsoleKey.DownArrow:
                    if (Heros.PositionX < Hauteur - 1)
                        Heros.PositionX++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (Heros.PositionY > 0)
                        Heros.PositionY--;
                    break;
                case ConsoleKey.RightArrow:
                    if (Heros.PositionY < Largeur - 1)
                        Heros.PositionY++;
                    break;
                case ConsoleKey.NumPad0:
                    if (Heros.Sac.Count >= 1)
                        Heros.Utiliser(0);
                    break;
                case ConsoleKey.NumPad1:
                    if (Heros.Sac.Count >= 2)
                        Heros.Utiliser(1);
                    break;
                case ConsoleKey.NumPad2:
                    if (Heros.Sac.Count >= 3)
                        Heros.Utiliser(2);
                    break;
                case ConsoleKey.NumPad3:
                    if (Heros.Sac.Count >= 4)
                        Heros.Utiliser(3);
                    break;
                case ConsoleKey.NumPad4:
                    if (Heros.Sac.Count >= 5)
                        Heros.Utiliser(4);
                    break;
            }
        }

        public void Contact()
        {
            foreach (Personnage ennemie in Ennemis)
            {
                if (Heros.PositionX == ennemie.PositionX && Heros.PositionY == ennemie.PositionY)
                {
                    Personnage.Combat(Heros, ennemie);
                    Ennemis.Remove(ennemie);
                    break;
                }
            }
            foreach (Objet item in Objets)
            {
                if (Heros.PositionX == item.PositionX && Heros.PositionY == item.PositionY)
                {
                    Heros.Sac.Add(item);
                    Objets.Remove(item);
                    break;
                }
            }
        }
    }
}
