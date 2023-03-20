using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.ClassesMetier
{
    class Stockage
    {
        private int numero;
        private int capaciteMaxi;
        private int capaciteDispo;

        public Stockage(int capaciteMaxi, int capaciteDispo)
        {
            CapaciteMaxi = capaciteMaxi;
            CapaciteDispo = capaciteDispo;
        }

        public int Numero { get => numero; }
        public int CapaciteMaxi { get => capaciteMaxi; set => capaciteMaxi = value; }
        public int CapaciteDispo { get => capaciteDispo; set => capaciteDispo = value; }






    }
}
