using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxConsole
{
    class Combat
    {
        public Personnage Personnage1 { get; set; }
        public Personnage Personnage2 { get; set; }

        public void Resoudre()
        {
            Console.Clear();

            Console.WriteLine(Personnage1.Information);
            Console.WriteLine("VS");
            Console.WriteLine(Personnage2.Information);
            Console.WriteLine("");
            Personnage p1, p2;
            if (Personnage1.Vitesse >= Personnage2.Vitesse)
            {
                p1 = Personnage1;
                p2 = Personnage2;
            }
            else
            {
                p1 = Personnage2;
                p2 = Personnage1;
            }

            while (p1.PV > 0 && p2.PV > 0)
            {
                p1.Attaque(p2);
                if (p2.PV > 0)
                {
                    p2.Attaque(p1);
                }
            }
            Console.WriteLine("");
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
