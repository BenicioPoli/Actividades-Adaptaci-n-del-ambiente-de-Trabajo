using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public CajaDeAhorro(){
           saldo = 0; 
        }
        
        public override bool extraer(decimal monto)
        {
            if (monto > 0 && monto <= saldo)
            {
                saldo -= monto;
                return true;
            }
            else
            {
                Console.WriteLine("No money? pobreton");
                return false;
            }
        }
    }
}
