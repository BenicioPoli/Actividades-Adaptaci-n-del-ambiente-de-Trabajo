using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ej6
{
    public class Mazo
    {   

        List<Carta> cartas { get; set; }
        public Mazo()
        {
            cartas = new List<Carta>();
            for(int i = 1; i <= 12; i++)
            {
                cartas.Add(new Carta("Oro", i));
                cartas.Add(new Carta("Copa", i));
                cartas.Add(new Carta("Espada", i));
                cartas.Add(new Carta("Basto", i));
            }
        }

        public void barajar()
        {
            Carta[] cartasArray = cartas.ToArray();

            Random.Shared.Shuffle(cartasArray);

            cartas = cartasArray.ToList();
        }

        public Carta robarCarta()
        {
            if (cartas.Count == 0)
            {
                Console.WriteLine("No hay más cartas para robar.");
                return null;
            }
            else
            {
                Carta cartaRobada = cartas[0];
                cartas.RemoveAt(0);
                return cartaRobada;
            }
        }

        public int cuantasCartasQuedan()
        {
            return cartas.Count;
        }

    }
}
