using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5
{
    public class Banco
    {
        private List<CuentaBancaria> cuentasBancarias = new List<CuentaBancaria>();
        public void agregarCuenta(CuentaBancaria cuenta)
        {
            cuentasBancarias.Add(cuenta);
        }

        public void transferir(CuentaBancaria origen, CuentaBancaria destino, decimal monto)
        {
            bool flagDestino = false;
            bool flagOrigen = false;

            if (monto > 0) {
                foreach (CuentaBancaria cuenta in cuentasBancarias)
                {
                    if (cuenta == origen)
                    {
                        flagOrigen = true;
                    }
                    if (cuenta == destino)
                    {
                        flagDestino = true;
                    }
                }
                if (flagOrigen && flagDestino && origen.extraer(monto))
                {
                    destino.depositar(monto);
                }
                    
            }   
        }
    }
}
