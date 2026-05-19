
namespace Formas
{
    public class Cuadrado : Figura
    {
    
        private float lado;
        public float Lado
        {
            get { return lado; }
            set { lado = value; }
        }

        public Cuadrado(float lado)
        {
            this.lado = lado;
            _nombre = "Cuadrado";
        }
        public override double CalcularArea()
        {
            return lado * lado;
        }
        public override double CalcularPerimetro()
        {
            return 4 * lado;
        }
    }
}
