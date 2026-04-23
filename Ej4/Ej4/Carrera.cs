using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4
{
    internal class Carrera
    {
        public IVehiculo Vehiculo1;
        public IVehiculo Vehiculo2;
        public int tiempo;
        public Carrera(IVehiculo v1,IVehiculo v2,int tiempo)
        {
            Vehiculo1 = v1;
            this.tiempo = tiempo;
            Vehiculo2 = v2;
        }

        public void IniciarCarrera()
        {
            Vehiculo1.mover(tiempo);
            Vehiculo2.mover(tiempo);
            Console.WriteLine($"Posicion del Vehiculo 1: {Vehiculo1.obtPosicion()}");
            Console.WriteLine($"Posicion del Vehiculo 2: {Vehiculo2.obtPosicion()}");
            if (Vehiculo1.obtPosicion() > Vehiculo2.obtPosicion())
            {
                Console.WriteLine("Gano el Vehiculo 1");
            }
            else if (Vehiculo1.obtPosicion() < Vehiculo2.obtPosicion())
            {
                Console.WriteLine("Gano el Vehiculo 2");
            }
            else
            {
                Console.WriteLine("Empate");
            }
        }
    }
}
