
namespace Formas
{
    public class Figura
    {
        protected string _nombre  { get; set; }
        public Figura() { }
        public virtual double CalcularArea() { return 0; }

        public virtual double CalcularPerimetro() { return 0; }

        public void MostrarInformacion() 
        {
            Console.WriteLine($"{_nombre}: Área = {CalcularArea()}, Perímetro = {CalcularPerimetro()}");
        }
    }
}
