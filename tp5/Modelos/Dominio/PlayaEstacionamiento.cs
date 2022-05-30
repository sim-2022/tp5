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

        public void EstacionarAuto(double tiempoRelojSalida, TipoAuto auto, int tiempoPermanencia)
        {
            var sectorLibre = Sectores.First(sector => sector.EstadoSector is EstadoSector.Libre);
            Sectores.Remove(sectorLibre);
            Sectores.Add(Sector.CrearSectorOcupado(sectorLibre.Id, auto, tiempoRelojSalida, tiempoPermanencia));
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
                if (evento == TipoEvento.FinCobro) //Se agrega para que muestre disponible en la columna Estado Cobro si no hay autos en la cola.
                    return "Disponible";
                return "Ocupado";
            }
            else if (Vector.LstCobro.Count > 1) //Si hay autos en la cola el estado de cobro se mantiene en ocupado
                return "Ocupado";

            return "Disponible";
        }       
        /// <summary>
        /// Calcula cuantos autos hay en la cola
        /// Se le resta 1 xq no se tiene en cuenta al que ya se le esta cobrando
        /// </summary>
        /// <returns></returns>
        public int CalcularColaCobro() => Vector.LstCobro.Count == 0 ? 0 : Vector.LstCobro.Count - 1;
        public int CalcularGanancia(TipoAuto tipoAuto, int tiempo) => tipoAuto == TipoAuto.Pequeño ? 80 * tiempo : tipoAuto == TipoAuto.Grande ? 100 * tiempo : 150 * tiempo;
        public void DesocuparSector(int id)
        {
            var sectorPorDesocupar = Sectores.First(sector => sector.Id == id);
            Sectores.Remove(sectorPorDesocupar);
            Sectores.Add(Sector.CrearSectorLibre(sectorPorDesocupar.Id));
        }
        /// <summary>
        /// Calcula el fin de cobro
        /// </summary>
        /// <param name="tiempoCobro"></param>
        /// <param name="reloj"></param>
        /// <returns></returns>
        public double CalcularFinCobro(double tiempoCobro, double? reloj = null)
        {
            if (Vector.LstCobro.Any())
            {
                double finCobro = Vector.LstCobro.First().InicioCobro + tiempoCobro;
                Vector.LstCobro.First().FinCobro = finCobro;

                if (reloj.HasValue && finCobro == reloj.Value) //Si no hay autos en la cola devuelve 0 una vez que finalizo el cobro para que no muestre info en la columna Fin Cobro
                    finCobro = 0;                

                return finCobro;
            }
            return 0;
        }
        /// <summary>
        /// Actualiza el inicio de cobro del que sigue en la cola
        /// </summary>
        public void ActualizarFinCobro() 
        {
            var finPrimeroEnCola = Vector.LstCobro.First().FinCobro;
            var siguienteEnCola = Vector.LstCobro[1];

            siguienteEnCola.InicioCobro = finPrimeroEnCola;
            Vector.LstCobro.RemoveAt(0);
        }        
    }
}