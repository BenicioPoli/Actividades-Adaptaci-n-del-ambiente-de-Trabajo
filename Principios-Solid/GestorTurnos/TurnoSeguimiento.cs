using System;
using System.Collections.Generic;
using System.Text;

namespace GestorTurnos
{
    internal class TurnoSeguimiento: TurnoTipo
    {
        public override string nombreTipo()
        {
            return "Seguimiento";
        }

        public override decimal ObtenerPrecio()
        {
            return 3000;
        }
    }
}
