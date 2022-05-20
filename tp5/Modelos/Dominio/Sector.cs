using tp5.Modelos.Dominio.Enumeradores;
using tp5.Utilidades;

namespace tp5.Modelos.Dominio
{
    public struct Sector
    {
        public int Id { get; private set; }
        public TipoAuto? TipoAuto { get; private set; }
        public int Salida { get; private set; }
        public static Sector CrearSectorLibre(int id) => new Sector() { Id = id };
        public EstadoSector EstadoSector => TipoAuto is null ? EstadoSector.Libre : EstadoSector.Ocupado;
        public string Estado => EstadoSector.ObtenerDescripcion();
        
        public void Estacionar(TipoAuto tipoAuto, int tiempoRelojSalida)
        {
            TipoAuto = tipoAuto;
            Salida = tiempoRelojSalida;
        }
        
        public void Desocupar()
        {
            TipoAuto = null;
            Salida = -1;
        }

        public static Sector CrearSectorOcupado(int sectorLibreId, TipoAuto auto, int tiempoRelojSalida)
        {
            return new Sector()
            {
                Id = sectorLibreId,
                TipoAuto = auto,
                Salida = tiempoRelojSalida
            };
        }
    }
}