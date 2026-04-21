using System;
using System.Runtime.InteropServices;

namespace Ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Semaforo sema = new Semaforo("verde");
            sema.pasoDelTiempo(60);
            sema.mostrarColor();
            sema.ponerEnInterminente();
            sema.mostrarColor();
        }
    }
}
