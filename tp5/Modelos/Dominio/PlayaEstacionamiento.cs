using System;
using System.Collections.Generic;
using System.Linq;
using tp5.Modelos.Dominio.Enumeradores;

namespace tp5.Modelos.Dominio
{
    public class PlayaEstacionamiento
    {
        public Dictionary<int, EstadoSector> Sectores;    
        private int CantidadSectores { get; set; }
        public static int IdAuto;

        public PlayaEstacionamiento(int cantidadSectores)
        {
            CantidadSectores = cantidadSectores;
            var objSector = new Sector(CantidadSectores);
            Sectores = objSector.Sectores;
        }

        private PlayaEstacionamiento()
        {
        }

        public PlayaEstacionamiento Clonar()
        {
            return new PlayaEstacionamiento
            {
                CantidadSectores = CantidadSectores,
                Sectores = Sectores
            };
        }

        public void EstacionarAuto(int permanencia, TipoAuto tipoAuto, double fin)
        {            
            var sectorLibre = Sectores.First(sector => sector.Value is EstadoSector.Libre);
            Sectores[sectorLibre.Key] = EstadoSector.Ocupado;
            Auto objAuto = new Auto(IdAuto ,tipoAuto, permanencia, fin, sectorLibre.Key);
            Vector.LstAutos.Add(objAuto);
            IdAuto++;
        }

        public IEnumerable<KeyValuePair<int, EstadoSector>> ProximoSectorPorDesocupar()
        {
            var listaSectoresOcupados = Sectores
                .Where(sector => sector.Value is EstadoSector.Ocupado)                
                .ToList();

            if (!listaSectoresOcupados.Any())
                throw new Exception("No hay sectores por desocupar.");
            yield return listaSectoresOcupados.First();
        }

        public Auto GetSalidaAuto() 
        {
            var objAuto = Vector.LstAutos.Where(auto => auto.Existe == true && auto.Estado == EstadoAuto.Estacionado).OrderBy(auto => auto.FinEstacionamiento).ToList().First();            
            return objAuto;
        }
        public int ContarSectoresOcupados() => Sectores.Count(sector => sector.Value is EstadoSector.Ocupado);
        public bool HayLugar() => Sectores.Any(sector => sector.Value is EstadoSector.Libre);
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
            var sectorPorDesocupar = Sectores.First(sector => sector.Key == id);
            Sectores[sectorPorDesocupar.Key] = EstadoSector.Libre;
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

        public void EliminarAuto(int id) 
        {
            Vector.LstAutos[id].Existe = false;
        }

        public double GetPorcentajeOcupacion(double reloj, double media, int sectoresOcupados) => (1/reloj) * ((reloj - 1) * (media + sectoresOcupados))        ;
    }
}