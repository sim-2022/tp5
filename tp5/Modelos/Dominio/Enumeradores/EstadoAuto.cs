using System.ComponentModel;

namespace tp5.Modelos.Dominio.Enumeradores
{
    public enum EstadoAuto
    {
        [Description("Estacionado")]
        Estacionado,
        [Description("Pagando")]
        Pagando
    }
}