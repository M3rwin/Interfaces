using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.ClassesMetier
{
    class Tanker :Navire, INavCommercable
    {
        private string typeFluide;

        public Tanker(string imo, string nom, string latitude, 
            string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT, string typeFluide)
            :base(imo,nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.typeFluide = typeFluide;
        }

        public string TypeFluide { get => typeFluide; set => typeFluide = value; }

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
