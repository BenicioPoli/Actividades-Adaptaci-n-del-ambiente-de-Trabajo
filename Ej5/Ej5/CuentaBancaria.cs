using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class CuentaBancaria
    {
        protected decimal saldo { get; set; }

        public CuentaBancaria() { }
        public void depositar(decimal monto){
            if (monto > 0)
            {
                saldo += monto;
            }
        
        }
        public virtual bool extraer(decimal monto)
        {
            return false;
        }
        
        public void mostrarSaldo()
        {
            Console.WriteLine($"Saldo actual: {saldo}");
        }
    }
}
