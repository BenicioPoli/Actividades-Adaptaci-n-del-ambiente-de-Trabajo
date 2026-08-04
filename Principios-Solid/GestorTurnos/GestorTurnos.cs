using System;

namespace GestorTurnos
{
    public class GestorTurnos
    {
        public void ProcesarTurno(Paciente paciente,string TipoTurno)
        {
            
            if (paciente == null)
            {
                Console.WriteLine("El paciente no se encuentra en los sistemas.");
                return;
            }

            int validar_turno = Validaciones.ValidarTurno(paciente, TipoTurno);

            if (validar_turno == 0)
            {
                Console.WriteLine("El tipo de turno es invalido.");
                return;
            }

            TurnoTipo turnoTipo = new TurnoTipo(TipoTurno);
            Turno turno = new Turno(turnoTipo, paciente);
            turno.Guardar();
            turno.Notificar();  
            turno.ImprimirComprobante();
               
            
        }
    }
}
