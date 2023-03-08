using Interfaces.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.ClassesMetier
{
    abstract class Navire
    {
        protected readonly string imo;
        protected readonly string nom;
        protected double latitude;
        protected double longitude;
        protected int tonnageActuel;
        protected int tonnageGT;
        protected int tonnageDWT;

        public string Imo { get => imo;}
        public string Nom { get => nom;}
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
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

        protected Navire(string imo, string nom, double latitude, double longitude, int tonnageActuel, int tonnageGT, int tonnageDWT)
        {
            this.imo = imo;
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.TonnageActuel = tonnageActuel;
            this.tonnageGT = tonnageGT;
            this.tonnageDWT = tonnageDWT;
        }


    }
}
