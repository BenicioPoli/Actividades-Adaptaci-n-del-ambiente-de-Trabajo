using ClinicaMedica;
using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClinicaContext context = new ClinicaContext();
            var gestorTurnos = new GestorTurnos();

            //seleccionar y cargar todos los turnos y sus relaciones
            var turnos = context.Turnos
                .Include(t => t.Paciente)
                .Include(t => t.Medico)
                .Include(t => t.Especialidad)
                .Include(t => t.Estado)
                .OrderBy(t => t.Fecha)
                .ThenBy(t => t.Hora)
                .ToList();

            foreach (var t in turnos)
            {
                Console.WriteLine($"{t.Fecha} {t.Hora} | {t.Paciente.Nombre} {t.Paciente.Apellido} | {t.Medico.Nombre} {t.Medico.Apellido} | {t.Especialidad.Nombre} | {t.Estado.Descripcion}");
            }

            var turnos2 = context.Turnos.Where(t => t.Estado.Descripcion == "cancelado");
            foreach (var turno in turnos2)
            {
                
                Console.WriteLine($"{turno.Estado.Descripcion} | {turno.Especialidad.Nombre} | {turno.Paciente.Nombre}");
            }

            Paciente paciente = context.Pacientes.FirstOrDefault(p => p.Dni == 27999000);
            Console.WriteLine($"{paciente.Nombre} {paciente.Apellido}");

            Console.WriteLine("Ingrese Dni del paciente a buscar:");
            int dni = int.Parse(Console.ReadLine());

            Paciente paciente2 = context.Pacientes.FirstOrDefault(p => p.Dni == dni);

            if (paciente2 == null) {
                Console.WriteLine("No esta en el sistema registrese");
                paciente2 = gestorTurnos.RegistroPaciente(dni, context);
            }
            else
            {
                paciente2.MostrarDatos();
                var turnosDelPaciente = turnos.Where(t => t.Paciente.Dni == dni);
                   
                Console.WriteLine("Turnos del Paciente:");
                foreach (var turno in turnosDelPaciente)
                {
                    Console.WriteLine($"{turno.Fecha} {turno.Hora} | {turno.Medico.Nombre} {turno.Medico.Apellido} | {turno.Especialidad.Nombre} | {turno.Estado.Descripcion}");
                }
                Console.WriteLine("Desea Cancelar un Turno(Responder con Si/No): ");
                string respuesta = (Console.ReadLine()).ToLower();
                if (respuesta == "si")
                {
                    gestorTurnos.CancelarTurno(context,paciente2);
                }
            }
            Console.WriteLine("Desea Reservar un Nuevo Turno(Responder con Si/No): ");
            string respuesta2 = (Console.ReadLine()).ToLower();
            if(respuesta2 == "si")
            {
                gestorTurnos.ReservaTurno(context,dni);
            }
        }
    }
}
