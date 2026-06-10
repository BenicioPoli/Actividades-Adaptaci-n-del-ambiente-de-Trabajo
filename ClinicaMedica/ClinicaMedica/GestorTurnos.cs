using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace ClinicaMedica
{
    public class GestorTurnos
    {
        public void CancelarTurno(ClinicaContext context,Paciente Paciente)
        {
            Console.WriteLine("Dia del Turno: ");
            string dia = Console.ReadLine();
            Console.WriteLine("Hora de Turno: ");
            string hora = Console.ReadLine();

            Turno turnoACancelar = context.Turnos.FirstOrDefault(t =>
             t.Paciente.Dni == Paciente.Dni &&
             t.Fecha == dia &&
             t.Hora == hora);

            if (turnoACancelar == null)
            {
                Console.WriteLine("No se pudo cancelar el turno");
            }
            else
            {
                turnoACancelar.CancelarTurno(context);
                Console.WriteLine("Turno cancelado exitosamente.");
            }
         }

        public Especialidad EleccionEspecialidad(ClinicaContext context)
        {
            Console.WriteLine("Especialidades disponibles: ");
            foreach (Especialidad especialidad in context.Especialidades)
            {
                Console.WriteLine($"{especialidad.Nombre}");
            }
            Console.WriteLine("Ingrese la especialidad deseada: ");
            string especialidadDeseada = Console.ReadLine().ToLower();
            Especialidad especialidadElegida = context.Especialidades.FirstOrDefault(e => (e.Nombre).ToLower() == especialidadDeseada);
            while (especialidadElegida == null)
            {
                Console.WriteLine("Especialidad no encontrada,ingresela nuevamente: ");
                especialidadDeseada = Console.ReadLine().ToLower();
                especialidadElegida = context.Especialidades.FirstOrDefault(e => (e.Nombre).ToLower() == especialidadDeseada);
            }
            return especialidadElegida;
        }

        public Medico EleccionMedico(ClinicaContext context, int idEspecialidad) {
            var medicosDisponibles = context.MedicoEspecialidades
                .Where(me => me.IdEspecialidad == idEspecialidad)
                .Select(me => me.Medico)
                .ToList();

            Console.WriteLine("Medicos disponibles para la especialidad seleccionada: ");
            foreach (var medico in medicosDisponibles) 
            {
                Console.WriteLine($"{medico.Nombre} {medico.Apellido}");
            }
            Console.WriteLine("Ingrese el nombre del medico deseado: ");
            string nombreMedico = Console.ReadLine().ToLower();
            Console.WriteLine("Ingrese el apellido del medico deseado: ");
            string apellidoMedico = Console.ReadLine().ToLower();
            Medico medicoElegido = context.Medicos.FirstOrDefault(m => (m.Nombre).ToLower() == nombreMedico && (m.Apellido).ToLower() == apellidoMedico);
            while (medicoElegido == null)
            {
                Console.WriteLine("Medico no encontrado,ingreselo nuevamente: ");
                Console.WriteLine("Ingrese el nombre del medico: ");
                nombreMedico = Console.ReadLine().ToLower();
                Console.WriteLine("Ingrese el apellido del medico: ");
                apellidoMedico = Console.ReadLine().ToLower();
                medicoElegido = context.Medicos.FirstOrDefault(m => (m.Nombre).ToLower() == nombreMedico && (m.Apellido).ToLower() == apellidoMedico);
            }
            return medicoElegido;
        }

        public (string Fecha,string Hora) EleccionFechaHora(ClinicaContext context,int idEspecialidad,int matriculaMedico)
        {
            Console.WriteLine("A continuacion se diran los horarios de atencion del medico en la especialidad elegida: ");
            string[] nombresDias = { "", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };

            foreach (Disponibilidad disponibilidad in context.Disponibilidades)
            {
                if (disponibilidad.Matricula == matriculaMedico && disponibilidad.IdEspecialidad == idEspecialidad)
                {
                    string diaEnLetras = nombresDias[disponibilidad.DiaSemana];
                    Console.WriteLine($"Dia de atencion: {diaEnLetras} Horario:{disponibilidad.HoraInicio} a {disponibilidad.HoraFin}");
                }
            }
            Console.WriteLine("Ingrese Fecha del Turno deseada (ej: 2026-06-20): ");
            string fechaString = Console.ReadLine();

            DateTime fechaParseada;

          
            while (!DateTime.TryParse(fechaString, out fechaParseada))
            {
                Console.WriteLine("Error: Formato de fecha invalido. Ingrésela nuevamente (ej: 2026-10-25): ");
                fechaString = Console.ReadLine();
            }

            int numeroDia = (int)fechaParseada.DayOfWeek;
            bool medicoAtiende = context.Disponibilidades.Any(d => d.Matricula == matriculaMedico && d.DiaSemana == numeroDia);
            if (!medicoAtiende)
            {
                Console.WriteLine("El médico no atiende ese día de la semana. Vuelva a elegir la Fecha");
                return EleccionFechaHora(context, idEspecialidad, matriculaMedico);
            }

            Console.WriteLine("Ingrese la Hora del Turno (ej: 20:30): ");
            string horaString = Console.ReadLine();
            TimeSpan horaParseada;

            while (!TimeSpan.TryParseExact(horaString, "h\\:mm", null, out horaParseada))
            {
                Console.WriteLine("Error: Formato de hora invalido. Ingrésela nuevamente (ej: 19:20): ");
                horaString = Console.ReadLine();
            }
            var disponibilidadesDelDia = context.Disponibilidades
            .Where(d => d.Matricula == matriculaMedico && d.DiaSemana == numeroDia)
            .ToList();
          
            bool horaValida = disponibilidadesDelDia.Any(d =>
                horaParseada >= TimeSpan.Parse(d.HoraInicio) &&
                horaParseada <= TimeSpan.Parse(d.HoraFin));

            if (!horaValida)
            {
                Console.WriteLine("El médico no atiende en ese horario. Vuelva a elegir la Fecha y Hora.");
                return EleccionFechaHora(context, idEspecialidad, matriculaMedico);
            }
            bool turnoOcupado = context.Turnos.Any(t =>
            t.Medico.Matricula == matriculaMedico &&
            t.Fecha == fechaString &&
            t.Hora == horaString &&
            t.Estado.Descripcion != "cancelado");

            if (turnoOcupado)
            {
                Console.WriteLine("Ese horario ya está ocupado. Vuelva a elegir la Fecha y Hora.");
                return EleccionFechaHora(context, idEspecialidad, matriculaMedico);
            }
            return (fechaString, horaString);
        }

        public void ReservaTurno(ClinicaContext context, int dni)
        {
            Especialidad especialidadTurno = EleccionEspecialidad(context);
            int idEspecialidad = especialidadTurno.IdEspecialidad;
            Medico medicoTurno = EleccionMedico(context, idEspecialidad);
            int matriculaMedico = medicoTurno.Matricula;
            var (fechaElegida, horaElegida) = EleccionFechaHora(context, idEspecialidad, matriculaMedico);
            Console.WriteLine("A continuacion los datos del Turno: ");
            Console.WriteLine($"Medico: {medicoTurno.Apellido} {medicoTurno.Nombre} Especialidad: {especialidadTurno.Nombre}");
            Console.WriteLine($"Fecha Turno:{fechaElegida} Hora Turno:{horaElegida}");

            Console.WriteLine("Desea confirmar el turno(Contestar con Si/No): ");
            string respuesta = (Console.ReadLine()).ToLower();
            if (respuesta == "si")
            {
                Turno nuevoTurno = new Turno(context, dni, matriculaMedico, idEspecialidad, fechaElegida, horaElegida);
                context.Turnos.Add(nuevoTurno);
                context.SaveChanges();
                Console.WriteLine("Turno Creado con Exito");
            }
        }


        public Paciente RegistroPaciente(int dni, ClinicaContext context)
        {
            Console.WriteLine("Ingrese nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido:");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese telefono:");
            string telefono = Console.ReadLine();
            Console.WriteLine("Ingrese email:");
            string mail = Console.ReadLine();
            Console.WriteLine("Ingrese fecha de nacimiento:");
            string fechaNacimiento = Console.ReadLine();
            Paciente nuevoPaciente = new Paciente(dni, nombre, apellido, telefono, mail, fechaNacimiento);
            context.Pacientes.Add(nuevoPaciente);
            context.SaveChanges();
            return nuevoPaciente;
        }
    }
}