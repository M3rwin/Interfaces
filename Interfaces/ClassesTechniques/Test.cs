using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.ClassesMetier;

namespace Interfaces.ClassesTechniques
{
    public class Test
    {
        public static void ChargementIinitial(Port port)
        {
            try
            {
                //cargos
                port.EnregistrerArrivePrevue(new Cargo("IMO97808594", "CMA CMGM A. LINCOLN", "43.43279N", "134.76258W", 100872, 148992, 123000, "marchandises diverses"));
                port.EnregistrerArrivePrevue(new Cargo("IMO09250098", "CONTAINERSHIPS VII", "43.43279N", "134.76258W", 100872, 148992, 123000, "des jouets"));
                Console.WriteLine(port);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void AfficheAttendus(Port port)
        {
            string message = "\n---------------------------------------\nListe des bateaux en attente de leur arrivée";
            if (port.NavireAttendus.Count > 0)
            {
                foreach (KeyValuePair<string, Navire> navire in port.NavireAttendus)
                {
                    message += $"\n{navire.Key}\t{navire.Value.Nom} : {navire.Value.GetType().Name}";
                }
            }
        }


        public static void TestEnregistrerArriveePrevue(Port port, Navire navire)
        {
            try
            {
                port.EnregistrerArrivePrevue(navire);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static void TestEnregistrerArrivee(Port port, string imo)
        {
            try
            {
                port.EnregistrerArrivePrevue(new Tanker(imo, "Test", "0.0", "0.0", 0, 0, 1000, "none"));
                port.EnregistrerArrivee(imo);
                Console.WriteLine("navire "+imo+" arrivé");
                port.EnregistrerArrivee(imo);
              
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }


        public static void TestEnregistrerDepart(Port port, String imo)
        {
            try
            {
                port.EnregistrerDepart(imo);
                Console.WriteLine("navire " + imo + " parti");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
