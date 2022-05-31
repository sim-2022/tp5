using System.Collections.Generic;
using tp5.Modelos.Dominio.Enumeradores;

namespace tp5.Modelos.Dominio
{
    public class Sector
    {
        public Dictionary<int, EstadoSector> Sectores = new Dictionary<int, EstadoSector>();

        public Sector(int cantidad) 
        {
            for (var i = 0; i < cantidad; i++)
                Sectores.Add(i, EstadoSector.Libre);
        }        
    }
}