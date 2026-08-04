using System;

namespace GestorTurnos
{
    public abstract class TurnoTipo //clase abstracta no se puede instanciar directamente,tambien se puede hacer con atributos en vez de funciones
    {
        public virtual string nombreTipo()
        {
            return "Turno";
        }

        public virtual decimal ObtenerPrecio()
        {
            return 3000;
        }
    }
}