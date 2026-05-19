
namespace Formas
{
    internal class Triangulo : Figura
    {
        private float lado { get; set; }
        private float altura { get; set; }

        public Triangulo(float lado, float altura)
        {
            this.lado = lado;
            this.altura = altura;
            _nombre = "Triangulo";
        }
        public override double CalcularArea()
        {
            return lado * altura;
        }

        public override double CalcularPerimetro()
        {
            return 3 * lado;
        }
    }
}
