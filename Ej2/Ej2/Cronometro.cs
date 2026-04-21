using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2
{
    internal class Cronometro
    {
        public int segundos;
        public int minutos;
        public void reiniciar()
        {
            segundos = 0;
            minutos = 0;
        }
        public void incrementarTiempo()
        {
            segundos++;
            if (segundos > 59)
            {
                minutos++;
                segundos = 0;
            }
        }
        public void mostrarTiempo()
        {
            Console.WriteLine($"{minutos}:{segundos}");
        }
    }
}
