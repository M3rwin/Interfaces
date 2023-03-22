using System;
using Interfaces.ClassesMetier;
using Interfaces.ClassesTechniques;
namespace Interfaces
{
    class Program
    {
        static void Main()
        {
            try
            {




                Port port = new Port("Marseille", "43.2976N", "5.3471E", 4, 4, 3, 2);
                //Test.ChargementIinitial(port);
                Console.WriteLine(port);
                //Test.AfficheAttendus(port);

                //Test.TestEnregistrerArriveePrevue(port, new Cargo("IMO9780859", "CMA CGM A. LINCOLN", "43.43279 N", "134.76258 W",
                //140872, 148992, 123000, "marchandises diverses"));
                /*		 
                 * enregistrement de l'arrivée d'un Navire de la classe Croisiere
                 * Il y a toujours de la place.
                 */
                Test.TestEnregistrerArrivee(port, "IMO9241061");

                /*
                 *  Dans ce test, on essaie d'enregistrer l'arrivée d'un navire
                 *  qui n'est pas attendu dans le port 
                 *  */
                //Test.TestEnregistrerArrivee(port, "IMO0000000");

                /**
                 * Dans ce test, on essaie d'enregistrer l'arrivée d'un navire 
                 * qui est déjà dans le port 
                 */
                //Test.TestEnregistrerArrivee(port, "IMO9241061");
                /**
                 * Dans ce test, on enregistre l'arrivée d'un petit tanker attendu
                 * et il y a de la place. 
                 */
                //Test.TestEnregistrerArrivee(port, "IMO9334076");
                /*
                 * On rajoute 2 super tankers qui sont attendus, 
                 */
                Test.TestEnregistrerArrivee(port, "IMO9197832");
                Test.TestEnregistrerArrivee(port, "IMO9220952");

                /*
                * Arrivée d'un super tanker attendu , il doit être mis en attente
                */
                Test.TestEnregistrerArrivee(port, "IMO9379715");

                /*
                 * On essaie de faire partir un navire qui n'est pas arrivé
                 */
                Test.TestEnregistrerDepart(port, "IMO9197822");
                /*
                 * On fait partir le navire de croisière, 
                 * il y a toujours ls super tanker en attente
                 */
                
                Test.TestEnregistrerDepart(port, "IMO9241061");
                Console.WriteLine(port);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur " + ex.Message);
            }
            
            Console.ReadKey();
        }
    }
}







///*
// * On fait partir le tanker, 
// * le super tanker doit rester en attente
// */
//Test.TestEnregistrerDepart(port, "IMO9334076");

///*
// * On fait partir le super tanker, celui en attente doit arriver
// */
//Test.TestEnregistrerDepart(port, "IMO9197832");

///*
//* Dans ce test, on enregistre l'arrivée de 4 cargos
//* et il y a de la place. 
//*/
//Test.TestEnregistrerArriveePrevue(port, new Cargo("IMO9755933", "MSC DIANA", "39.74224 N", "5.99304 E",
//        193489, 202036, 176000, "Matériel industriel"));
//Test.TestEnregistrerArriveePrevue(port, new Cargo("IMO9204506", "HOLANDIA", "41.74844 N", "6.87008 E",
//        8737, 9113, 7500, "marchandises diverses"));
//Test.TestEnregistrerArrivee(port, "IMO9780859");
//Test.TestEnregistrerArrivee(port, "IMO9250098");
//Test.TestEnregistrerArrivee(port, "IMO9502910");
//Test.TestEnregistrerArrivee(port, "IMO9755933");

///*
//* Dans ce test on va enregistrer l'arrivée d'un cargo qui sera mis en attente
//*/
//Test.TestEnregistrerArrivee(port, "IMO9204506");

///*
//* 
//* Dans ce test on va enregistrer le départ d'un super tanker
//* Le cargo devrait rester en attente
//*/
//Test.TestEnregistrerDepart(port, "IMO9220952");

///*
//* Dans ce test on va enregistrer le départ d'un cargo
//* Le cargo en attente devrait passer dans les navires arrivés
//*/
//Test.TestEnregistrerDepart(port, "IMO9755933");

//Console.WriteLine(port);