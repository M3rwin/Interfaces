using System;
using Interfaces.ClassesMetier;
using Interfaces.ClassesTechniques;
namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Port monPort = new Port("Toulon", "43.2976N", "5.3471E", 4, 3, 2, 4);
                Console.WriteLine(monPort);
                Test.

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
