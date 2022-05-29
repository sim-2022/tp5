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

        public void EstacionarAuto(double tiempoRelojSalida, TipoAuto auto)
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
        public bool HayAutoXCobrar() => Vector.LstCobro.Any();        
        public string GetEstadoCobro(TipoEvento evento) 
        {
            if (Vector.LstCobro.Count == 1)
            {
                if (evento == TipoEvento.FinCobro)
                    return "Disponible";
                return "Ocupado";
            }
            else if (Vector.LstCobro.Count > 1)
                return "Ocupado";

            return "Disponible";
        }       
        public int CalcularColaCobro() => Vector.LstCobro.Count == 0 ? 0 : Vector.LstCobro.Count - 1;
        public void DesocuparSector(int id)
        {
            var sectorPorDesocupar = Sectores.First(sector => sector.Id == id);
            Sectores.Remove(sectorPorDesocupar);
            Sectores.Add(Sector.CrearSectorLibre(sectorPorDesocupar.Id));
        }
        public double CalcularFinCobro(double tiempoCobro)
        {
            if (Vector.LstCobro.Any())
            {
                double finCobro = Vector.LstCobro.First().InicioCobro + tiempoCobro;
                Vector.LstCobro.First().FinCobro = finCobro;

                return finCobro;
            }
            return 0;
        }
        public void ActualizarFinCobro() 
        {
            var finPrimeroEnCola = Vector.LstCobro.First().FinCobro;
            var siguienteEnCola = Vector.LstCobro[1];

            siguienteEnCola.InicioCobro = finPrimeroEnCola;
            Vector.LstCobro.RemoveAt(0);
        }
        
    }
}