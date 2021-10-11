using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxConsole
{
    class Personnage
    {
        public string Nom { get; set; }
        public string Type { get; set; }
        public int PV { get; set; }
        public int Force { get; set; }
        public int Resistance { get; set; }
        public int Vitesse { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Position { get { return Nom + "(" + PositionX + ";" + PositionY + ")"; } }
        public string Information { get { return Nom + "(" + Type + ")" + Environment.NewLine + "PV:" + PV + " Force:" + Force + " Résistance:" + Resistance + " Vitesse:" + Vitesse; } }

        public Personnage(string vNom, string vType, int vPV, int vForce, int vResistance, int vVitesse, int vPositionX, int VPositionY)
        {
            Nom = vNom;
            Type = vType;
            PV = vPV;
            Force = vForce;
            Resistance = vResistance;
            Vitesse = vVitesse;
            PositionX = vPositionX;
            PositionY = VPositionY;
        }

        public int Attaque(Personnage ennemi)
        {
            int degats = Force - ennemi.Resistance;
            if (degats < 0)
            {
                degats = 1;
            }
            ennemi.PV -= degats;
            if (ennemi.PV < 0)
            {
                ennemi.PV = 0;
            }
            Console.WriteLine(Nom + " attaque ! --> " + ennemi.Nom + " " + ennemi.PV + "PV");
            return degats;
        }

        public static void Combat(Personnage attaquant, Personnage defenseur)
        {
            Console.Clear();

            Console.WriteLine(attaquant.Information);
            Console.WriteLine("VS");
            Console.WriteLine(defenseur.Information);

            Personnage p1, p2;
            if (attaquant.Vitesse >= defenseur.Vitesse)
            {
                p1 = attaquant;
                p2 = defenseur;
            }
            else
            {
                p1 = defenseur;
                p2 = attaquant;
            }

            while (p1.PV > 0 && p2.PV > 0)
            {
                p1.Attaque(p2);
                if (p2.PV > 0)
                {
                    p2.Attaque(p1);
                }
            }

            if (p1.PV <= 0)
            {
                Console.WriteLine(p1.Nom + " a été vaincu !");
            }
            else
            {
                Console.WriteLine(p2.Nom + " a été vaincu !");
            }

            Console.ReadLine();
        }
    }
}
