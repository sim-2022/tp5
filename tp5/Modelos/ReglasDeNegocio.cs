using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp5.Modelos
{
    class ReglasDeNegocio
    {
        public ReglasDeNegocio() { }
        public double Truncar4Decimales(double numero)
        {
            var numeroRedondeado = Math.Truncate(numero * 10000) / 10000;
            return numeroRedondeado;
        }
    }
}
