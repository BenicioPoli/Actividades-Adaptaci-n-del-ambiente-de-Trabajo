using System;

namespace GestorTurnos
{
    public class Turno
    {
        public Paciente paciente { get; set; }
        public string tipoTurno { get; set; }
        public decimal precio { get; set; }

        public Turno(Paciente paciente, string tipoTurno)
        {
            this.paciente = paciente;
            this.tipoTurno = tipoTurno;
            switch (this.tipoTurno)
            {
                case "Normal":
                    precio = 5000;
                    break;
                case "Urgente":
                    precio = 7500;
                    break;
                case "Seguimiento":
                    precio = 3000;
                    break;
            }

        }
        
        public void ImprimirComprobante()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("           COMPROBANTE DE TURNO - CLÍNICA           ");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Paciente:   {paciente.nombrePaciente}");
            Console.WriteLine($"DNI:        {paciente.dni}");
            Console.WriteLine($"Email:      {paciente.email}");
            Console.WriteLine($"Tipo turno: {tipoTurno}");
            Console.WriteLine($"Precio:     ${precio}");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();

        }
    }
}

