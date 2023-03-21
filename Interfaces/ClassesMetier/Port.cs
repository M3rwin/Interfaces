using Interfaces.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.ClassesMetier
{
    public class Port
    {

        // Attributs

        private readonly string nom;
        private readonly string latitude;
        private readonly string longitude;
        private int nbPortique;
        private int nbQuaisPassager;
        private int nbQuaisTanker;
        private int nBQuaisSuperTanker;
        private Dictionary<string, Navire> navireAttendus = new Dictionary<string, Navire>();
        private Dictionary<string, Navire> navireArrives = new Dictionary<string, Navire>();
        private Dictionary<string, Navire> navirePartis = new Dictionary<string, Navire>();
        private Dictionary<string, Navire> navireEnAttente = new Dictionary<string, Navire>();
        private Dictionary<int, Stockage> stockages = new Dictionary<int, Stockage>();


        // Constructeur

        public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisPassager, int nbQuaisTanker, int nBQuaisSuperTanker)
        {
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.nbPortique = nbPortique;
            this.nbQuaisPassager = nbQuaisPassager;
            this.nbQuaisTanker = nbQuaisTanker;
            this.nBQuaisSuperTanker = nBQuaisSuperTanker;
        }


        // Properties 

        public string Nom => nom;

        public string Latitude => latitude;

        public string Longitude => longitude;

        public int NbPortique { get => nbPortique; set => nbPortique = value; }
        public int NbQuaisPassager { get => nbQuaisPassager; set => nbQuaisPassager = value; }
        public int NbQuaisTanker { get => nbQuaisTanker; set => nbQuaisTanker = value; }
        public int NBQuaisSuperTanker { get => nBQuaisSuperTanker; set => nBQuaisSuperTanker = value; }
        internal Dictionary<string, Navire> NavireAttendus { get => navireAttendus; set => navireAttendus = value; }
        internal Dictionary<string, Navire> NavireArrives { get => navireArrives; set => navireArrives = value; }
        internal Dictionary<string, Navire> NavirePartis { get => navirePartis; set => navirePartis = value; }
        internal Dictionary<string, Navire> NavireEnAttente { get => navireEnAttente; set => navireEnAttente = value; }
        internal Dictionary<int, Stockage> Stockages { get => stockages; set => stockages = value; }

        // Méthodes Enregistrer 

        public void EnregistrerArriveePrevue(Navire nav)
        {
            this.NavireAttendus.Add(nav.Imo, nav);
        }


        public void EnregistrerArrivee(Navire nav)
        {
            if (this.NavireAttendus.ContainsKey(nav.Imo))
            {
                if(nav is Tanker)
                {
                    if(nav.TonnageGT > 130000)
                    {
                        if(nBQuaisSuperTanker-1 < 0)
                        {
                            Console.WriteLine("Plus de quais disponible, plassé en file d'attente");
                            this.navireEnAttente.Add(nav.Imo, nav);
                        }
                        else { nBQuaisSuperTanker--; this.navireArrives.Add(nav.Imo, nav); }
                    }
                    else
                    {
                        if(nbQuaisTanker-1 < 0)
                        {
                            Console.WriteLine("Plus de quais disponible, plassé en file d'attente");
                            this.navireEnAttente.Add(nav.Imo, nav);
                        }
                        else { nbQuaisTanker--; this.navireArrives.Add(nav.Imo, nav); }
                    }
                }
                else if(nav is Cargo)
                {
                    if(nbPortique-1 <= 0)
                    {
                        Console.WriteLine("Plus de quais disponible, plassé en file d'attente");
                        this.navireEnAttente.Add(nav.Imo, nav);
                    }
                    else { nbPortique--; this.navireArrives.Add(nav.Imo, nav); }
                }
                else if(nav is Croisiere)
                {
                    if(nbQuaisPassager-1 <= 0)
                    {
                        Console.WriteLine("Plus de quais disponible, plassé en file d'attente");
                        this.navireEnAttente.Add(nav.Imo, nav);
                    }
                    else { nbQuaisPassager--; this.navireArrives.Add(nav.Imo, nav); }
                }
            }
            else
            {
                throw new GestionPortException("Le navire n'est pas attendu");
            }
        }

        public void EnregistrerArrivee(string imo)
        {
            if (this.NavireAttendus.ContainsKey(imo))
            {
                Navire nav = this.navireAttendus[imo];
                if (nav is Tanker)
                {
                    if (nav.TonnageGT > 130000)
                    {
                        if (nBQuaisSuperTanker - 1 <= 0)
                        {
                            Console.WriteLine("Plus de quais disponible, plassé en file d'attente");
                            this.navireEnAttente.Add(nav.Imo, nav);
                        }
                        else { nBQuaisSuperTanker--; this.navireArrives.Add(nav.Imo, nav); }
                    }
                    else
                    {
                        if (nbQuaisTanker - 1 <= 0)
                        {
                            Console.WriteLine("Plus de quais disponible, plassé en file d'attente");
                            this.navireEnAttente.Add(nav.Imo, nav);
                        }
                        else { nbQuaisTanker--; this.navireArrives.Add(nav.Imo, nav); }
                    }
                }
                else if (nav is Cargo)
                {
                    if (nbPortique - 1 <= 0)
                    {
                        Console.WriteLine("Plus de quais disponible, plassé en file d'attente");
                        this.navireEnAttente.Add(nav.Imo, nav);
                    }
                    else { nbPortique--; this.navireArrives.Add(nav.Imo, nav); }
                }
                else if (nav is Croisiere)
                {
                    if (nbQuaisPassager - 1 <= 0)
                    {
                        Console.WriteLine("Plus de quais disponible, plassé en file d'attente");
                        this.navireEnAttente.Add(nav.Imo, nav);
                    }
                    else { nbQuaisPassager--; this.navireArrives.Add(nav.Imo, nav); }
                }
            }
            else
            {
                throw new GestionPortException("Le navire n'est pas attendu");
            }
        }
        

        public void EnregistrerDepart(Navire nav)
        {
            if (this.NavireArrives.ContainsKey(nav.Imo))
            {
                this.navireArrives.Remove(nav.Imo);
                this.NavirePartis.Add(nav.Imo, nav);
            }else
            {
                throw new GestionPortException("Le Navire n'est pas arrivé dans le port");
            }
        }
        public void AjoutNavireEnAttente(Navire nav)
        {
            if (this.NavireAttendus.ContainsKey(nav.Imo))
            {
                this.navireAttendus.Remove(nav.Imo);
                this.NavireEnAttente.Add(nav.Imo, nav);
            }
            else
            {
                throw new GestionPortException("Le navire n'est pas attendu");
            }
        }


        public bool EstAttendu(string imo)
        {
            return this.NavireAttendus.ContainsKey(imo);
        }

        public bool EstPresent(string imo)
        {
            return this.navireArrives.ContainsKey(imo);
        }
        

        public bool EstEnAttente(string imo)
        {
            return this.navireEnAttente.ContainsKey(imo);
        }


        public void Chargement(string imo, int qte)
        {
            Navire navire = this.navireArrives[imo];
            if(navire.TonnageActuel+qte <= navire.TonnageDWT)
            {
                navire.TonnageActuel += qte;
            }
            else { throw new GestionPortException("Capacité insuffisante."); }
        }


        public void Dechargement(string imo, int qte)
        {
            Navire navire = this.navireArrives[imo];
            if(navire.TonnageActuel-qte >= 0)
            {
                navire.TonnageActuel -= qte;
            }
            else { throw new GestionPortException("Le bateau ne contient pas autant de chargement."); }
        }


        //Methodes Get

        public Object GetUnAttendu(string imo)
        {
            return this.navireAttendus[imo];
        }
        public Object GetUnArrive(string imo)
        {
            return this.NavireArrives[imo];
        }
        public Object GetUnParti(string imo)
        {
            return this.navirePartis[imo];
        }
        public int GetNbTankerArrives()
        {
            int cpt=0;
            foreach(KeyValuePair<string, Navire> cle in navireArrives)
            {
                if (cle.Value.TonnageGT <= 130000 && cle.Value.GetType().Name=="Tanker")
                {
                    cpt += 1;
                }
            }
            return cpt;
        }


        public int GetNbSuperTankerArrives()
        {
            int cpt = 0;
            foreach (KeyValuePair<string, Navire> cle in navireArrives)
            {
                if (cle.Value.TonnageGT >= 130000)
                {
                    cpt += 1;
                }
            }
            return cpt;
        }


        public int GetNbCargoArrives()
        {
            int cpt = 0;
            foreach (KeyValuePair<string, Navire> cle in navireArrives)
            {
                if (cle.Value.GetType().Name == "Cargo")
                {
                    cpt += 1;
                }
            }
            return cpt;
        }



        public override string ToString()
        {
            string message = $@"Port de {this.nom} :
    Coordonnées GPS : {this.latitude} / {this.longitude}
    Nb portiques : {this.nbPortique}
    Nb quais croisière : {this.nbQuaisPassager}
    Nb quais tanker : {this.nbQuaisTanker}
    Nb quais SuperTanker : {this.nBQuaisSuperTanker}
    Nb navires à quai : {this.navireArrives.Count}
    Nb navires attendus : {this.navireAttendus.Count}
    Nb navires à partir : {this.navirePartis.Count}
    Nb navires en attente : {this.navireEnAttente.Count}

Nombre de cargos dans le port : {GetNbCargoArrives()}
Nombre de tankers dans le port : {GetNbTankerArrives()}
Nombre de super tankers dans le port : {GetNbSuperTankerArrives()}";
            return message;
        }

    }
}
