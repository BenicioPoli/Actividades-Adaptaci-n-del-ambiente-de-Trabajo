using System;

namespace GestorTurnos
{
    public class GestorTurnos
    {
        public void ProcesarTurno(Paciente paciente,string tipoTurno)
        {
            
            if (paciente == null)
            {
                Console.WriteLine("El paciente no se encuentra en los sistemas.");
                return;
            }

            int validar_turno = Validaciones.ValidarTurno(paciente, tipoTurno);

            if (validar_turno == 0)
            {
                Console.WriteLine("El tipo de turno es invalido.");
                return;
            }

            TurnoTipo turnoTipo = null;

            switch (tipoTurno)
            {
                case "Normal":
                     turnoTipo = new TurnoNormal();
                    break;
                case "Urgente":
                    turnoTipo = new TurnoUrgente();
                    break;
                case "Seguimiento":
                    turnoTipo = new TurnoSeguimiento();
                    break;
            }
            
            Turno turno = new Turno(turnoTipo, paciente);
            turno.Guardar();
            turno.Notificar();  
            turno.ImprimirComprobante();
               
            
        }
    }
}
