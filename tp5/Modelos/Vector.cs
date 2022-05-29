using System;
using System.Collections.Generic;
using System.Linq;
using tp5.Modelos.Dominio.Enumeradores;
using PlayaEstacionamiento = tp5.Modelos.Dominio.PlayaEstacionamiento;

namespace tp5.Modelos
{
    public class Vector
    {
        #region Propiedades

        private readonly ReglasDeNegocio _reglasDeNegocio = new ReglasDeNegocio();        
        public static int CantidadSectores = 10;
        public static int Lambda;
        public static int TiempoCobro;
        public static List<Cobro> LstCobro = new List<Cobro>();                
        public double finCobro;

        public TipoEvento Evento { get; private set; }
        public double Reloj { get; private set; }
        public double RandomLlegadaAuto { get; private set; }
        public double TiempoLlegadaAuto { get; private set; }
        public double ProximaLlegadaAuto { get; private set; }
        public double RandomTipoAuto { get; private set; }
        public double RandomTiempoRelojSalidaAuto { get; private set; }
        public TipoAuto TipoAuto { get; private set; }
        public PlayaEstacionamiento PlayaEstacionamiento { get; private set; }
        public int CantidadAutosSinEntrar { get; private set; }
        public int CantidadSectoresOcupados { get; private set; }
        public string EstadoCobro { get; private set; }
        public int ColaCobro { get; private set; }        
        public double FinCobro { get; private set; }
        #endregion

        #region Comportamiento

        private TipoEvento ObtenerProximoTipoEvento()
        {
            var listaProximosEventos = new List<(TipoEvento TipoEvento, double Tiempo)>()
            {
                (TipoEvento.LlegadaAuto, ProximaLlegadaAuto),
            };

            if (PlayaEstacionamiento.HayAlgunAuto())
            {
                var proximoSectorPorLiberar = PlayaEstacionamiento.ProximoSectorPorDesocupar();
                var eventoFinEstacionamiento =
                    (TipoEvento.FinEstacionamiento, TiempoRelojSalida: proximoSectorPorLiberar.Salida);
                listaProximosEventos.Add(eventoFinEstacionamiento);                
            }
     
            if (PlayaEstacionamiento.HayAutoXCobrar()) 
            {
                finCobro = PlayaEstacionamiento.CalcularFinCobro(TiempoCobro);
                var eventoFinCobro =
                   (TipoEvento.FinCobro, TiempoRelojSalida: finCobro);
                listaProximosEventos.Add(eventoFinCobro);
            }

            var siguienteEvento = listaProximosEventos                
                .OrderBy(evento => evento.Tiempo)
                .First();            

            return siguienteEvento.TipoEvento;
        }

        #endregion

        #region Simulaciones

        public static Vector SimularInicio()
        {
            ReglasDeNegocio _reglasDeNegocio = new ReglasDeNegocio();
            var random = new Random();
            const int tiempoInicio = 0;
            var tiempoLlegadaAuto = _reglasDeNegocio.GenerarVariableExpNeg(_reglasDeNegocio.GenerarRandom(), Lambda);
            return new Vector
            {
                Reloj = tiempoInicio,
                Evento = TipoEvento.Inicio,
                TiempoLlegadaAuto = tiempoLlegadaAuto,
                ProximaLlegadaAuto = tiempoLlegadaAuto,
                PlayaEstacionamiento = new PlayaEstacionamiento(CantidadSectores)
            };
        }

        public Vector SimularSiguienteEstado()
        {
            var simulacionPorEvento = new Dictionary<TipoEvento, Func<Vector>>
            {
                { TipoEvento.LlegadaAuto, SimularLlegadaAuto },
                { TipoEvento.FinEstacionamiento, SimularFinEstacionamiento },
                { TipoEvento.FinCobro, SimularFinCobro}
            };

            var proximoTipoEvento = ObtenerProximoTipoEvento();

            if (!simulacionPorEvento.ContainsKey(proximoTipoEvento))
                throw new Exception($"No se esperaba recibir el tipo de evento: {proximoTipoEvento}");

            return simulacionPorEvento[proximoTipoEvento]();
        }

        private Vector SimularLlegadaAuto()
        {            
            var randomTipoAuto = _reglasDeNegocio.GenerarRandom();
            var tipoAuto = TipoAutoSegunNumeroAleatorio(randomTipoAuto);

            var randomTiempoRelojSalidaAuto = _reglasDeNegocio.GenerarRandom();
            var tiempoRelojSalidaAuto = ProximaLlegadaAuto +
                                        TiempoEstacionadoSegunNumeroAleatorio(randomTiempoRelojSalidaAuto);

            var cantidadAutosSinEntrar = CantidadAutosSinEntrar;

            var randomLlegadaAuto = _reglasDeNegocio.GenerarRandom();
            var tiempoLlegadaAuto = _reglasDeNegocio.GenerarVariableExpNeg(randomLlegadaAuto, Lambda);
            var proximaLlegadaAuto = ProximaLlegadaAuto + tiempoLlegadaAuto;

            var playaEstacionamiento = PlayaEstacionamiento.Clonar();
            if (playaEstacionamiento.HayLugar())
                playaEstacionamiento.EstacionarAuto(tiempoRelojSalidaAuto, tipoAuto);
            else
                cantidadAutosSinEntrar += 1;

            var tipoEvento = TipoEvento.LlegadaAuto;

            var nuevoVector = new Vector
            {
                Reloj = ProximaLlegadaAuto,
                Evento = TipoEvento.LlegadaAuto,
                RandomLlegadaAuto = randomLlegadaAuto,
                TiempoLlegadaAuto = tiempoLlegadaAuto,
                ProximaLlegadaAuto = proximaLlegadaAuto,
                RandomTipoAuto = randomTipoAuto,
                TipoAuto = tipoAuto,
                RandomTiempoRelojSalidaAuto = randomTiempoRelojSalidaAuto,
                PlayaEstacionamiento = playaEstacionamiento,
                CantidadAutosSinEntrar = cantidadAutosSinEntrar,
                CantidadSectoresOcupados = playaEstacionamiento.ContarSectoresOcupados(),
                EstadoCobro = playaEstacionamiento.GetEstadoCobro(tipoEvento),
                ColaCobro = playaEstacionamiento.CalcularColaCobro(),
                FinCobro = playaEstacionamiento.CalcularFinCobro(TiempoCobro),
            };
            return nuevoVector;
        }

        private Vector SimularFinEstacionamiento()
        {            
            var sectorPorDesocupar = PlayaEstacionamiento.ProximoSectorPorDesocupar();
            var tiempoSalida = sectorPorDesocupar.Salida;
            var playaEstacionamiento = PlayaEstacionamiento.Clonar();
            var tipoEvento = TipoEvento.FinEstacionamiento;
            playaEstacionamiento.DesocuparSector(sectorPorDesocupar.Id);
            Cobro _cobro = new Cobro(tiempoSalida, tiempoSalida, 0);
            LstCobro.Add(_cobro);

            var nuevoVector = new Vector
            {
                Reloj = tiempoSalida,
                Evento = tipoEvento,
                TiempoLlegadaAuto = TiempoLlegadaAuto,
                ProximaLlegadaAuto = ProximaLlegadaAuto,
                RandomTipoAuto = RandomTipoAuto,
                TipoAuto = TipoAuto,
                RandomTiempoRelojSalidaAuto = RandomTiempoRelojSalidaAuto,
                PlayaEstacionamiento = playaEstacionamiento,
                CantidadAutosSinEntrar = CantidadAutosSinEntrar,
                CantidadSectoresOcupados = playaEstacionamiento.ContarSectoresOcupados(),
                EstadoCobro = playaEstacionamiento.GetEstadoCobro(tipoEvento),
                ColaCobro = playaEstacionamiento.CalcularColaCobro(),
                FinCobro = playaEstacionamiento.CalcularFinCobro(TiempoCobro),
            };            

            return nuevoVector;
        }

        public Vector SimularFinCobro()
        {
            var playaEstacionamiento = PlayaEstacionamiento.Clonar();
            var tipoEvento = TipoEvento.FinCobro;

            var nuevoVector = new Vector
            {
                Reloj = finCobro,
                Evento = TipoEvento.FinCobro,
                TiempoLlegadaAuto = TiempoLlegadaAuto,
                ProximaLlegadaAuto = ProximaLlegadaAuto,
                RandomTipoAuto = RandomTipoAuto,
                TipoAuto = TipoAuto,
                RandomTiempoRelojSalidaAuto = RandomTiempoRelojSalidaAuto,
                PlayaEstacionamiento = playaEstacionamiento,
                CantidadAutosSinEntrar = CantidadAutosSinEntrar,
                CantidadSectoresOcupados = playaEstacionamiento.ContarSectoresOcupados(),
                EstadoCobro = playaEstacionamiento.GetEstadoCobro(tipoEvento),
                ColaCobro = playaEstacionamiento.CalcularColaCobro(),
                FinCobro = playaEstacionamiento.CalcularFinCobro(TiempoCobro),
            };

            if (LstCobro.Count > 1)
                PlayaEstacionamiento.ActualizarFinCobro();
            else
                LstCobro.RemoveAt(0);

            nuevoVector.ColaCobro = playaEstacionamiento.CalcularColaCobro();
            return nuevoVector;
        }
        #endregion

        #region Utilidades

        private TipoAuto TipoAutoSegunNumeroAleatorio(double numeroAleatorio)
        {
            var limInf1 = _reglasDeNegocio.Truncar4Decimales(Convert.ToDouble(ClsProbabilidades.DataTableTamaño.Rows[0][3]));
            var limSup1 = _reglasDeNegocio.Truncar4Decimales(Convert.ToDouble(ClsProbabilidades.DataTableTamaño.Rows[0][4]));
            var limInf2 = _reglasDeNegocio.Truncar4Decimales(Convert.ToDouble(ClsProbabilidades.DataTableTamaño.Rows[1][3]));
            var limSup2 = _reglasDeNegocio.Truncar4Decimales(Convert.ToDouble(ClsProbabilidades.DataTableTamaño.Rows[1][4]));
            
            if (numeroAleatorio < 0)
                throw new ArgumentOutOfRangeException(nameof(numeroAleatorio));
            
            if (numeroAleatorio >= limInf1 && numeroAleatorio < limSup1)
                return TipoAuto.Pequeño;

            if (numeroAleatorio >= limInf2 && numeroAleatorio < limSup2)
                return TipoAuto.Grande;

            return TipoAuto.Utilitario;
        }

        private int TiempoEstacionadoSegunNumeroAleatorio(double numeroAleatorio)
        {
            var limInf1 = _reglasDeNegocio.Truncar4Decimales(Convert.ToDouble(ClsProbabilidades.DataTableTamaño.Rows[0][3]));
            var limSup1 = _reglasDeNegocio.Truncar4Decimales(Convert.ToDouble(ClsProbabilidades.DataTableTamaño.Rows[0][4]));
            var limInf2 = _reglasDeNegocio.Truncar4Decimales(Convert.ToDouble(ClsProbabilidades.DataTableTamaño.Rows[1][3]));
            var limSup2 = _reglasDeNegocio.Truncar4Decimales(Convert.ToDouble(ClsProbabilidades.DataTableTamaño.Rows[1][4]));
            var limInf3 = _reglasDeNegocio.Truncar4Decimales(Convert.ToDouble(ClsProbabilidades.DataTableTamaño.Rows[2][3]));
            var limSup3 = _reglasDeNegocio.Truncar4Decimales(Convert.ToDouble(ClsProbabilidades.DataTableTamaño.Rows[2][4]));

            if (numeroAleatorio < 0)
                throw new ArgumentOutOfRangeException(nameof(numeroAleatorio));

            if (numeroAleatorio >= limInf1 && numeroAleatorio < limSup1)
                return 60;

            if (numeroAleatorio >= limInf2 && numeroAleatorio < limSup2)
                return 120;

            if (numeroAleatorio >= limInf3 && numeroAleatorio < limSup3)
                return 180;

            return 240;
        }

        #endregion
    }
}