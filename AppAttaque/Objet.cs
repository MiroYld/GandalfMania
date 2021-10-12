using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxConsole
{
    class Objet
    {
        public string Nom { get; set; }
        public string Competence { get; set; }
        public int Valeur { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Objet()
        { }

        public Objet(string vNom, string vCompetence, int vValeur, int vPositionX, int vPositionY)
        {
            Nom = vNom;
            Competence = vCompetence;
            Valeur = vValeur;
            PositionX = vPositionX;
            PositionY = vPositionY;
        }
    }
}
