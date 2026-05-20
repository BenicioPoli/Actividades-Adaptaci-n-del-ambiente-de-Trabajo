using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej6
{
    public class Carta
    {
        public string palo { get; }
        public int valor { get; }

        public Carta(string palo, int valor)
        {
            this.palo = palo;
            this.valor = valor;
        }
    }
}
