using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3
{
    internal interface IJugador
    {
        public int tiempo { get; set; }
        public bool correr(int minutos);
        public bool cansado();
        public void descansar(int minutos);

    }
}
