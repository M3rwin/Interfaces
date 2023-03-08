using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Exceptions
{
    class GestionPortException : Exception
    {
        public GestionPortException(string message) : base("Erreur le " + DateTime.Now.Date + " à " + DateTime.Now.TimeOfDay + "\n" +message) { }
    }
}
