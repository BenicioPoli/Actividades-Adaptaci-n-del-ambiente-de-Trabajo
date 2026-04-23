using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4
{
    internal class Auto:IVehiculo
    {
        public int posicion { get; set; }
        public int velocidad { get; set; }
        public Auto()
        {
            posicion = 0;
            velocidad = 40;
        }
        public Auto(int velocidad)
        {
            posicion = 0;
            this.velocidad = velocidad;
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
