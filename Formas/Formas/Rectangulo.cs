
namespace Formas
{
    public class Rectangulo : Figura
    {
        private float baseRectangulo { get; set; }
        private float alturaRectangulo { get; set; }

        public Rectangulo(float baseRectangulo, float alturaRectangulo)
        {
            this.baseRectangulo = baseRectangulo;
            this.alturaRectangulo = alturaRectangulo;
            _nombre = "Rectangulo";
        }
        public override double CalcularArea()
        {
            return baseRectangulo * alturaRectangulo;
        }

        public override double CalcularPerimetro()
        {
            return 2 * (baseRectangulo + alturaRectangulo);
        }
    }
}
