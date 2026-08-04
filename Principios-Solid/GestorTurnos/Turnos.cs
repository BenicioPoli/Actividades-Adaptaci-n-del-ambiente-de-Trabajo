using System;

namespace GestorTurnos
{
    public class Turno
    {
        public Paciente paciente { get; set; }
        public TurnoTipo turnoTipo { get; set; }

        private int TurnoID;

        public Turno(TurnoTipo turnoTipo, Paciente paciente)
        {
            this.turnoTipo = turnoTipo;
            this.paciente = paciente;
        }

        decimal CalcularPrecioTurno()
        {
            return turnoTipo.ObtenerPrecio();
        }


        public void Guardar()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("[BASE DE DATOS] Conectando a la base de datos...");
            Console.WriteLine($"[BASE DE DATOS] Insertando turno: Paciente={paciente.nombrePaciente}, DNI={paciente.dni}, Tipo={turnoTipo.NombreTipo}, Precio=${CalcularPrecioTurno()}");
            Console.WriteLine("[BASE DE DATOS] Turno guardado correctamente.");
            Console.WriteLine("----------------------------------------------------");
        }

        public void Notificar()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("[EMAIL] Conectando al servidor SMTP...");
            Console.WriteLine($"[EMAIL] Enviando confirmación de turno a {paciente.email}...");
            Console.WriteLine("[EMAIL] Email enviado correctamente.");
            Console.WriteLine("----------------------------------------------------");
        }

        public void ImprimirComprobante()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("           COMPROBANTE DE TURNO - CLÍNICA           ");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Paciente:   {paciente.nombrePaciente}");
            Console.WriteLine($"DNI:        {paciente.dni}");
            Console.WriteLine($"Email:      {paciente.email}");
            Console.WriteLine($"Tipo turno: {turnoTipo.NombreTipo}");
            Console.WriteLine($"Precio:     ${CalcularPrecioTurno()}");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();

        }
    }
}

