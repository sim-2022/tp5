using System.ComponentModel;

namespace tp5.Modelos.Dominio.Enumeradores
{
    public enum TipoEvento
    {
        [Description("Inicio")]
        Inicio,        
        [Description("Llegada Auto")]
        LlegadaAuto,
        [Description("Fin de Estacionamiento")]
        FinEstacionamiento,
        [Description("Fin de Cobro")]
        FinCobro
    }
}