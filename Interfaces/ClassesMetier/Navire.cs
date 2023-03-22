using Interfaces.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.ClassesMetier
{
    public class Navire
    {
        protected readonly string imo;
        protected readonly string nom;
        protected string latitude;
        protected string longitude;
        protected int tonnageActuel;
        protected int tonnageGT;
        protected int tonnageDWT;

        public string Imo { get => imo;}
        public string Nom { get => nom;}
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public int TonnageActuel
        {
            get => tonnageActuel;
            set
            {
                if (value < 0)
                {
                    throw new GestionPortException("Le tonnage ne peut pas etre negatif");
                }
                else if(value > tonnageDWT)
                {
                    throw new GestionPortException("La capacité maximal est atteinte");
                }
                else
                {
                    tonnageActuel = value;
                }
                
            }
        }
        public int TonnageGT { get => tonnageGT;}
        public int TonnageDWT { get => tonnageDWT; }

        protected Navire(string imo, string nom, string latitude, string longitude, int tonnageActuel, int tonnageGT, int tonnageDWT)
        {
            this.imo = imo;
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.tonnageGT = tonnageGT;
            this.tonnageDWT = tonnageDWT;
            this.TonnageActuel = tonnageActuel;
        }


    }
}
