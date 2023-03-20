using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Exceptions;
using Interfaces.Interfaces;

namespace Interfaces.ClassesMetier
{
    class Cargo : Navire, INavCommercable
    {
        private string typeFret;

        public Cargo(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT, string typeFret)
            :base(imo, nom, latitude, longitude,  tonnageActuel,  tonnageGT, tonnageDWT)
        {
            this.typeFret = typeFret;
        }

        public string TypeFret { get => typeFret; set => typeFret = value; }

        public void Decharger(int qte)
        {
            this.TonnageActuel -= qte;
        }

        public void Charger(int qte)
        {
            this.TonnageActuel += qte;
        }
    }
}
