using System;
using System.Collections.Generic;
using System.Text;

namespace GestorTurnos
{
    internal class TurnoUrgente : TurnoTipo
    {
        public override string nombreTipo()
        {
            return "Urgente";
        }

        public override decimal ObtenerPrecio()
        {
            return 7500;
        }
    }
}
