using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp5.Modelos
{
    public class Cobro
    {
        public double SalidaEstacionamiento;
        public double InicioCobro;
        public double FinCobro;
        public Cobro(double salidaEstacionamiento, double inicioCobro, double finCobro)
        {
            SalidaEstacionamiento = salidaEstacionamiento;
            InicioCobro = inicioCobro;
            FinCobro = finCobro;
        }

        public void AgregarCobro() => Vector.LstCobro.Add(this);     
    }
}
