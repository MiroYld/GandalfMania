using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxConsole
{
    class Carte
    {
        public Personnage Heros { get; set; }
        public List<Personnage> Ennemis { get; set; }
        public int Hauteur { get; set; }
        public int Largeur { get; set; }
        public Carte()
        {
            Ennemis = new List<Personnage>();
        }

        public Carte(int vHauteur, int vLargeur)
        {
            Ennemis = new List<Personnage>();
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
                    }
                    carte += contenu;
                }

                carte += "#";
                Console.WriteLine(carte);
            }
            Console.WriteLine(bordure);
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
        }
    }
}
