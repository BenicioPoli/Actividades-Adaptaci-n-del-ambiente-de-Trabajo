using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4
{
    internal class Bicicleta:IVehiculo
    {
        public int posicion { get; set; }
        public int velocidad { get; set; }
        public Bicicleta()
        {
            posicion = 0;
            velocidad = 10;
        }
        public void mover(int tiempo)
        {
            posicion += (velocidad*tiempo);
        }
        public int obtPosicion()
        {
            return posicion;
        }
        public void reiniciarposicion()
        {
            posicion = 0;
        }

    }
}
