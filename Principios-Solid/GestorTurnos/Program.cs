namespace GestorTurnos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var gestor = new GestorTurnos();

            var Paciente1 =  Validaciones.CrearPaciente("Juan Pérez", "30111222", "juan.perez@mail.com");

            var Paciente2 = Validaciones.CrearPaciente("María Gómez", "27888999", "maria.gomez@mail.com");

            var Paciente3 = Validaciones.CrearPaciente("Carlos Ruiz", "40555666", "carlos.ruiz@mail.com");
       

            // Ejemplos de prueba: turno Normal, Urgente y Seguimiento
            gestor.ProcesarTurno(Paciente1,"Normal");
            gestor.ProcesarTurno(Paciente2,"Urgente");
            gestor.ProcesarTurno(Paciente3,"Seguimiento");

            var Paciente4  = Validaciones.CrearPaciente("", "123", "email-invalido");
      
            gestor.ProcesarTurno(Paciente4,"Normal");


            var Paciente5 = Validaciones.CrearPaciente("Ana López", "35777888", "ana.lopez@mail.com");

            // Ejemplo con tipo de turno desconocido
            gestor.ProcesarTurno(Paciente5,"Telemedicina");

            /*
            
            Refactorizar en el siguiente orden, de S a D:

            --------------------------------------------------------------------
            S - Single Responsibility Principle (Principio de Responsabilidad Única)
            --------------------------------------------------------------------

            --------------------------------------------------------------------
            O - Open/Closed Principle (Principio de Abierto/Cerrado)
            --------------------------------------------------------------------

            --------------------------------------------------------------------
            L - Liskov Substitution Principle (Principio de Sustitución de Liskov)
            --------------------------------------------------------------------
            
            --------------------------------------------------------------------
            I - Interface Segregation Principle (Principio de Segregación de Interfaces)
            --------------------------------------------------------------------
            
            --------------------------------------------------------------------
            D - Dependency Inversion Principle (Principio de Inversión de Dependencias)
            --------------------------------------------------------------------
            */
        }
    }
}
