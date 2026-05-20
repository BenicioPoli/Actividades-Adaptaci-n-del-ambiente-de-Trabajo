using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ej6
{
    public class Mano
    {   
        public List<Carta> cartasMano { get; set; }

        public Mano()
        {
            cartasMano = new List<Carta>();
        }
        public void recibirCarta(Carta carta)
        {
            cartasMano.Add(carta);
        }

        public void mostrarMano()
        {
            foreach (Carta carta in cartasMano)
            {
                Console.WriteLine($"Carta: {carta.valor} de {carta.palo}");
            }
        }
        
        public int cantidadDeCartas()
        {
            return cartasMano.Count;
        }
    }
}
