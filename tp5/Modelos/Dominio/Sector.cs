using tp5.Modelos.Dominio.Enumeradores;
using tp5.Utilidades;

namespace tp5.Modelos.Dominio
{
    public struct Sector
    {
        public int Id { get; private set; }
        public double Salida { get; private set; }
        public string Estado => EstadoSector.ObtenerDescripcion();
        public TipoAuto? TipoAuto { get; private set; }
        public EstadoSector EstadoSector => TipoAuto is null ? EstadoSector.Libre : EstadoSector.Ocupado;
        
        public static Sector CrearSectorLibre(int id) => new Sector() { Id = id };
        public static Sector CrearSectorOcupado(int sectorLibreId, TipoAuto auto, double tiempoRelojSalida)
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