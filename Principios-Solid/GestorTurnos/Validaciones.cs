using System;

namespace GestorTurnos
{
    public class Validaciones
    {
        public static Paciente? CrearPaciente(string nombrePaciente, string dni, string email)
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

        public static int ValidarTurno(Paciente paciente, string tipoTurno)
        {
            if(tipoTurno == "Normal" || tipoTurno == "Urgente" || tipoTurno == "Seguimiento")
            {
                return 1;
            }
            else
            {
                Console.WriteLine("Tipo de turno desconocido");
                return 0;
            }
        }
    }
}
