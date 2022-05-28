using System;

namespace tp5.Modelos
{
    class ReglasDeNegocio
    {
        private static readonly Random Random = new Random();

        public double Truncar4Decimales(double numero)
        {
            var numeroRedondeado = Math.Truncate(numero * 10000) / 10000;
            return numeroRedondeado;
        }

        public double GenerarRandom() => Random.NextDouble();
        public double GenerarVariableExpNeg(double rnd, double lambda) => ((-1 / lambda) * Math.Log(1 - rnd)) * 100;        
    }
}
