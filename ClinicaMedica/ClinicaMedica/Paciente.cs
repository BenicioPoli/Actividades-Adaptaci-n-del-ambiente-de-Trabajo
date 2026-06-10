using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica
{
    public class Paciente
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string FechaNacimiento { get; set; }

        public void MostrarDatos()
        {
            Console.WriteLine($"Datos Paciente: {Nombre} {Apellido} {Telefono} {FechaNacimiento} {Email} ");
        }
        
        public Paciente(int Dni,string Nombre,string Apellido, string Telefono, string Email, string FechaNacimiento)
        {
            this.Dni = Dni;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Telefono = Telefono;
            this.Email = Email;
            this.FechaNacimiento = FechaNacimiento;
        }
        
    }
}
