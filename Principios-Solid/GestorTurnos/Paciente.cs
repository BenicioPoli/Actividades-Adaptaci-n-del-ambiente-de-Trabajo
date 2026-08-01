using System;

namespace GestorTurnos
{
    public class Paciente {
        public string nombrePaciente { get; set; }
        public string dni { get; set; }
        public string email { get; set;}

        public Paciente(string nombrePaciente, string dni, string email)
        {
            this.nombrePaciente = nombrePaciente;
            this.dni = dni;
            this.email = email;
        }
    }
}
