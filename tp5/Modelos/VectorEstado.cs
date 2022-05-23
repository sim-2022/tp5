namespace tp5.Modelos
{
    public class VectorEstado
    {
        private Vector _anterior;
        public Vector Actual { get; private set; }

        public VectorEstado() => Actual = Vector.SimularInicio();

        public void CalcularSiguienteEstado()
        {
            _anterior = Actual;
            Actual = _anterior.SimularSiguienteEstado();
        }
    }
}