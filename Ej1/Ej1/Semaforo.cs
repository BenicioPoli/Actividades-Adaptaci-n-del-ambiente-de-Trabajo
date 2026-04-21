using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{

    public class Semaforo
    {
        public string color;
        public int segundos;
        public bool intermitente;
        public Semaforo(string color)
        {
            this.color = color;
            this.segundos = 0;
            this.intermitente = false;
        }
        public void pasoDelTiempo(int segundosIng)
        {
            segundos += segundosIng;
            segundos = segundos % 54;
            for (int i = 0; i < 2 && intermitente == false; i++)
            {
                if (color == "rojo" && segundos >= 30)
                {
                    color = "rojo+amarillo";
                    segundos -= 30;
                }
                else if (color == "rojo+amarillo" && segundos >= 2)
                {
                    color = "verde";
                    segundos -= 2;
                }
                else if (color == "verde" && segundos >= 20)
                {
                    color = "amarillo";
                    segundos -= 20;
                }
                else if (color == "amarillo" && segundos >= 2)
                {
                   color = "rojo";
                   segundos -= 2;
                }
            }
            if(intermitente)
            {
                segundos = segundos % 2;
                if (segundos == 1 && color == "amarillo")
                {
                    color = "rojo";
                    segundos -= 1;
                }
                else if (segundos == 1 && color == "rojo")
                {
                    color = "amarillo";
                    segundos -= 1;
                }
            }

        }
        public void mostrarColor()
        {
            Console.WriteLine(this.color);
        }
        public void ponerEnInterminente()
        {
            intermitente = true;

            segundos = segundos % 2;
            color = "amarillo";
            if (segundos == 1 && color == "amarillo")
            {
                color = "rojo";
                segundos -= 1;
            }
            else if(segundos == 1 && color == "rojo")
            {
                color = "amarillo";
                segundos -= 1;
            }
        }
        public void sacarDeIntermitente()
        {
            intermitente = false;
        }
    }
}    
