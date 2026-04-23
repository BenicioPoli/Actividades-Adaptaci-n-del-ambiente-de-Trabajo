using System;

namespace Ej3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IJugador amateur = new JugadorAmateur();
            IJugador profesional = new JugadorProfesional();
            Console.WriteLine(amateur.correr(10));
            Console.WriteLine(amateur.correr(20));
            Console.WriteLine(amateur.cansado());
            amateur.descansar(15);
            Console.WriteLine(amateur.cansado());
            Console.WriteLine(amateur.correr(17));

        }
    }
}
