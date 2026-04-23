using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3
{
    internal class JugadorAmateur:IJugador
    {
        public int tiempo { get; set; }
        public JugadorAmateur()
        {
            tiempo = 20;
        }
        public bool correr(int minutos)
        {
            if(tiempo < minutos)
            {
                tiempo = 0;
                return false;
            }
            tiempo -= minutos;
            return true;
        }
        public bool cansado()
        {
            return (tiempo == 0);
        }

        public void descansar(int minutos)
        {
            if(tiempo + minutos > 20)
            {
                tiempo = 20;
            }
            else
            {
                tiempo += minutos;
            }
        }
    }
}
