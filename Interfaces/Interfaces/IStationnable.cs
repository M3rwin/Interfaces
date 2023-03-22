using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.ClassesMetier;

namespace Interfaces.Interfaces
{
    interface IStationnable
    {
        void EnregistrerArrivePrevue(Navire nav);
        void EnregistrerArrivee(string str);
        void EnregistrerDepart(string str);
        bool EstAttendu(string str);
        //bool EstParti(string str);
        bool EstPresent(string str);
        Object GetUnAttendu(string str);
        Object GetUnArrive(string str);
        Object GetUnParti(string str);
    }
}
