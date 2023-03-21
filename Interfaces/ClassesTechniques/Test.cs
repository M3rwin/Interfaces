using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.ClassesMetier;

namespace Interfaces.ClassesTechniques
{
    public class Test
    {
        public static void ChargementInitial(Port port)
        {
            try
            {
                //cargos
                port.EnregistrerArriveePrevue(new Cargo("IMO9780859", "CMA CMGM A. LINCOLN", "43.43279N", "134.76258W", 140872, 148992, 123000, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO09250098", "CONTAINERSHIPS VII", "43.43279N", "134.76258W", 140872, 148992, 123000, "des jouets"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
