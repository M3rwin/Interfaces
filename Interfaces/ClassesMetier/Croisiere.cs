using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Exceptions;
using Interfaces.Interfaces;

namespace Interfaces.ClassesMetier
{
    class Croisiere : Navire, ICroisiere
    {
        private string typeNavireCroisiere;
        private int nbPassagersMax;
        private Dictionary<string, Passager> passagers = new Dictionary<string, Passager>();

        public Croisiere(string imo, string nom, double latitude, double longitude, int tonnageActuel, int tonnageGT, int tonnageDWT, string typeNavireCroisiere, int nbPassagersMax)
            :base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.TypeNavireCroisiere = typeNavireCroisiere;
            this.nbPassagersMax = nbPassagersMax;
        }

        public string TypeNavireCroisiere { get => typeNavireCroisiere;
            set
            {
                if(value=="M" || value == "V")
                {
                    this.typeNavireCroisiere = value;
                }
                else { throw new GestionPortException("Non."); }
            } 
        }

        public void Embarquer(List<object> objects)
        {
            if (objects.Count + this.passagers.Count > this.nbPassagersMax)
            {
                throw new GestionPortException("Trop de passagers");
            }
            else
            {
                foreach (Passager p in objects)
                {
                    this.passagers.Add(p.NumPasseport, p);
                }
            }
        }

        public List<Object>? Debarquer(List<object> objects)
        {
            int index = 0;
            foreach(Passager p in objects)
            {
                if (this.passagers.ContainsKey(p.NumPasseport))
                {
                    this.passagers.Remove(p.NumPasseport);
                    objects.RemoveAt(index);
                }
                index += 1;
            }
            return objects;
        }
    }
}
