using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.ClassesMetier
{
    class Passager
    {
        private readonly string numPasseport;
        private readonly string nom;
        private readonly string prenom;
        private readonly string nationalite;

        public Passager(string numPasseport, string nom, string prenom, string nationalite)
        {
            this.numPasseport = numPasseport;
            this.nom = nom;
            this.prenom = prenom;
            this.nationalite = nationalite;
        }

        public string NumPasseport => numPasseport;

        public string Nom => nom;

        public string Prenom => prenom;

        public string Nationalite => nationalite;
    }
}
