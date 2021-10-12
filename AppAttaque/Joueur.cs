using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxConsole
{
    class Joueur : Personnage
    {
        public List<Objet> Sac { get; set; }
        public Joueur(string vNom, string vType, int vPV, int vForce, int vResistance, int vVitesse, int vPositionX, int VPositionY) : base(vNom, vType, vPV, vForce, vResistance, vVitesse, vPositionX, VPositionY)
        {
            Sac = new List<Objet>();
        }

        public void Utiliser(int vIndex)
        {
            switch (Sac[vIndex].Competence)
            {
                case "PV":
                    PV += Sac[vIndex].Valeur;
                    break;
                case "Force":
                    Force += Sac[vIndex].Valeur;
                    break;
                case "Resistance":
                    Resistance += Sac[vIndex].Valeur;
                    break;
                case "Vitesse":
                    Vitesse += Sac[vIndex].Valeur;
                    break;
            }
            Sac.RemoveAt(vIndex);
        }
        public string GetContenuSac()
        {
            string output = "";
            for (int i = 0; i < Sac.Count; i++)
            {
                output += "[" + i + "] " + Sac[i].Nom + "(" + Sac[i].Competence + "+" + Sac[i].Valeur + ") | ";
            }
            return output;
        }
    }
}
