using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Interfaces
{
    interface ICroisiere
    {
        public void Embarquer(List<object> objects);
        public List<Object> Debarquer(List<object> objects);

    }
}
