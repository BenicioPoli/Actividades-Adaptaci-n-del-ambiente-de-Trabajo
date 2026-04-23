using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4
{
    internal class Camion:IVehiculo
    {
        public int posicion { get; set; }
        public int velocidad { get; set; }
        public Camion()
        {
            posicion = 0;
            velocidad = 30;
        }
        public void mover(int tiempo)
        {
            posicion += (velocidad * tiempo);
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
