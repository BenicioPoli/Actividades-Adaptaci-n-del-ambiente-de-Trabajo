using System;

namespace GestorTurnos
{
    public class GestorTurnos
    {
        public void ProcesarTurno(Paciente paciente,string TipoTurno)
        {
            var creadores = new Creadores();

            if (paciente == null)
            {
                Console.WriteLine("El paciente no se encuentra en los sistemas.");
                return;
            }

            var turno = creadores.CrearTurno(paciente, TipoTurno);

            if (turno == null)
            {
                Console.WriteLine("El tipo de turno es invalido.");
                return;
            }


            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("[BASE DE DATOS] Conectando a la base de datos...");
            Console.WriteLine($"[BASE DE DATOS] Insertando turno: Paciente={paciente.nombrePaciente}, DNI={paciente.dni}, Tipo={turno.tipoTurno}, Precio=${turno.precio}");
            Console.WriteLine("[BASE DE DATOS] Turno guardado correctamente.");
            

       
            Console.WriteLine("[EMAIL] Conectando al servidor SMTP...");
            Console.WriteLine($"[EMAIL] Enviando confirmación de turno a {paciente.email}...");
            Console.WriteLine("[EMAIL] Email enviado correctamente.");

            turno.ImprimirComprobante();
               
            
        }
    }
}
