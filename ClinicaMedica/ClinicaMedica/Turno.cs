using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMedica
{
    public class Turno
    {
        public int Dni { get; set; }
        public int Matricula { get; set; }
        public int IdEspecialidad { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int IdEstado { get; set; }
        public string? Observaciones { get; set; }

        public void CancelarTurno(ClinicaContext context)
        {
            var estadoCancelado = context.Estados.FirstOrDefault(e => e.Descripcion == "cancelado");
            IdEstado = estadoCancelado.IdEstado;
            context.SaveChanges();
        }

        public Turno(ClinicaContext context, int Dni, int Matricula, int IdEspecialidad, string Fecha, string Hora) {
            this.Dni = Dni;
            this.Matricula = Matricula;
            this.IdEspecialidad = IdEspecialidad;
            this.Fecha = Fecha;
            this.Hora = Hora;
            var estadoReservado = context.Estados.FirstOrDefault(e => e.Descripcion == "reservado");
            IdEstado = estadoReservado.IdEstado;
        }

        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public Especialidad Especialidad { get; set; }
        public Estado Estado { get; set; }
    }
}
