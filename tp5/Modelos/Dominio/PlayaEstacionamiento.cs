using System;
using System.Collections.Generic;
using System.Linq;
using tp5.Modelos.Dominio.Enumeradores;

namespace tp5.Modelos.Dominio
{
    public class PlayaEstacionamiento
    {
        public List<Sector> Sectores;
        private int CantidadSectores { get; set; }

        public PlayaEstacionamiento(int cantidadSectores)
        {
            CantidadSectores = cantidadSectores;
            Sectores = new List<Sector>();
            for (var i = 1; i <= CantidadSectores; i++)
                Sectores.Add(Sector.CrearSectorLibre(i));
        }

        private PlayaEstacionamiento()
        {
        }

        public PlayaEstacionamiento Clonar()
        {
            return new PlayaEstacionamiento
            {
                CantidadSectores = CantidadSectores,
                Sectores = Sectores.ToList()
            };
        }

        public void EstacionarAuto(int tiempoRelojSalida, TipoAuto auto)
        {
            var sectorLibre = Sectores.First(sector => sector.EstadoSector is EstadoSector.Libre);
            Sectores.Remove(sectorLibre);
            Sectores.Add(Sector.CrearSectorOcupado(sectorLibre.Id, auto, tiempoRelojSalida));
        }

        public Sector ProximoSectorPorDesocupar()
        {
            var listaSectoresOcupados = Sectores
                .Where(sector => sector.EstadoSector is EstadoSector.Ocupado)
                .OrderBy(sector => sector.Salida)
                .ToList();

            if (!listaSectoresOcupados.Any())
                throw new Exception("No hay sectores por desocupar.");

            return listaSectoresOcupados.First();
        }

        public int ContarSectoresOcupados() => Sectores.Count(sector => sector.EstadoSector is EstadoSector.Ocupado);
        public bool HayLugar() => Sectores.Any(sector => sector.EstadoSector is EstadoSector.Libre);
        public bool HayAlgunAuto() => !HayLugar();

        public void DesocuparSector(int id)
        {
            var sectorPorDesocupar = Sectores.First(sector => sector.Id == id);
            Sectores.Remove(sectorPorDesocupar);
            Sectores.Add(Sector.CrearSectorLibre(sectorPorDesocupar.Id));
        }
    }
}