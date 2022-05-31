using tp5.Modelos.Dominio.Enumeradores;

namespace tp5.Modelos
{
    public class Auto
    {
        public TipoAuto Tipo;
        public int TiempoPermanencia;
        public double FinEstacionamiento;
        public int Sector;
        public EstadoAuto Estado;
        public int Id;
        public bool Existe;
        public double InicioCobro = 0;
        public double FinCobro = 0;        

        public Auto(int id, TipoAuto tipo, int permanencia, double fin, int sector)
        {
            Id = id;
            Tipo = tipo;
            TiempoPermanencia = permanencia;
            FinEstacionamiento = fin;
            Sector = sector;
            Estado = EstadoAuto.Estacionado;
            Existe = true;
        }
    }
}
