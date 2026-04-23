using System;

namespace Ej4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehiculo fiat = new Auto(45);
            IVehiculo toyota = new Auto();
            IVehiculo bici = new Bicicleta();
            IVehiculo camion = new Camion();
            bici.mover(20);
            Console.WriteLine(bici.obtPosicion());
            bici.mover(10);
            Console.WriteLine(bici.obtPosicion());
            bici.reiniciarposicion();
            Console.WriteLine(bici.obtPosicion());
            Carrera carrera1 = new Carrera(toyota, fiat, 10);
            carrera1.IniciarCarrera();
            Carrera carrera2 = new Carrera(bici, camion, 20);
            carrera2.IniciarCarrera();
        }
    }
}
