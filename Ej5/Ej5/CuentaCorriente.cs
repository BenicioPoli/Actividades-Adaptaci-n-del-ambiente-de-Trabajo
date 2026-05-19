using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    internal class CuentaCorriente : CuentaBancaria
    {
         private decimal limite { get; set; }
         public CuentaCorriente(decimal limite)
         {
            saldo = 0;
            this.limite = limite;
         }
        public override bool extraer(decimal monto)
        {
            if (monto > limite && monto <= (saldo-limite))
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
