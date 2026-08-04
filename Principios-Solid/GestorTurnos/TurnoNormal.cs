using System;
using System.Collections.Generic;
using System.Text;

namespace GestorTurnos
{
    internal class TurnoNormal : TurnoTipo
    {
        public override string nombreTipo()
        {
            return "Normal";
        }

        public override decimal ObtenerPrecio()
        {
            return 5000;
        }
    }
}
