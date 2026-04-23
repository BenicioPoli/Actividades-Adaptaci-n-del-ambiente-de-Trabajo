using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4
{
    internal interface IVehiculo
    {
        public int posicion { get; set; }
        public int velocidad { get; set; }
        public void mover(int tiempo);
        public int obtPosicion();
        public void reiniciarposicion();
    }
}
