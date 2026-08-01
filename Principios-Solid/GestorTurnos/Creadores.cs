using System;

namespace GestorTurnos
{
    public class Creadores
    {
        public Paciente CrearPaciente(string nombrePaciente, string dni, string email)
        {
            if (string.IsNullOrWhiteSpace(nombrePaciente))
            {
                Console.WriteLine("Error: el nombre del paciente es obligatorio.");
                return null;
            }

            if (string.IsNullOrWhiteSpace(dni) || dni.Length < 7)
            {
                Console.WriteLine("Error: el DNI ingresado no es válido.");
                return null;
            }

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                Console.WriteLine("Error: el email ingresado no es válido.");
                return null;
            }
            return new Paciente(nombrePaciente, dni, email);
        }

        public Turno CrearTurno(Paciente paciente, string tipoTurno)
        {
            if(tipoTurno == "Normal" || tipoTurno == "Urgente" || tipoTurno == "Seguimiento")
            {
                return new Turno(paciente, tipoTurno);
            }
            else
            {
                Console.WriteLine("Tipo de turno desconocido");
                return null;
            }
        }
    }
}
