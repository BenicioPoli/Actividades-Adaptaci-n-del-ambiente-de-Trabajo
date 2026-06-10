using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ClinicaMedica
{
    public class MedicoEspecialidad
    {
        public int Matricula { get; set; }
        public int IdEspecialidad { get; set; }
        public Medico Medico { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}