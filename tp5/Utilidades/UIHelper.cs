using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using tp5.Modelos;
using tp5.Modelos.Dominio.Enumeradores;

namespace tp5.Utilidades
{
    public static class UiHelper
    {
        private static double Redondear(double numero) => Math.Round(numero, 2);

        public static DataTable CrearEstructuraTabla()
        {
            var tabla = new DataTable();
            var columnas = new List<DataColumn>
            {
                new DataColumn("Fila", typeof(int)),
                new DataColumn("Evento"),
                new DataColumn("Reloj (Minutos)"),
                new DataColumn("Random Llegada Auto"),
                new DataColumn("Tiempo Llegada Auto"),
                new DataColumn("Proxima Llegada Auto"),
                new DataColumn("Random Tipo Auto"),
                new DataColumn("Tipo Auto"),
                new DataColumn("Random Tiempo Salida Auto"),
                new DataColumn("Estado Cobro"),
                new DataColumn("Fin Cobro"),
                new DataColumn("Cola Cobro"),
                //new DataColumn("Cantidad Sectores Ocupados"),
            };

            for (var i = 1; i <= Vector.CantidadSectores; i++)
            {
                columnas.Add(new DataColumn($"Estado [Sector {i}]"));
                columnas.Add(new DataColumn($"Auto [Sector {i}]"));
                columnas.Add(new DataColumn($"Salida [Sector {i}]"));
            }

            columnas.Add(new DataColumn("Cantidad Autos Sin Entrar"));

            tabla.Columns.AddRange(columnas.ToArray());

            return tabla;
        }

        public static void AgregarFilaEnTabla(DataTable tabla, Vector vector, int numeroFila)
        {
            var fila = tabla.NewRow();
            fila["Fila"] = numeroFila;
            fila["Evento"] = vector.Evento.ObtenerDescripcion();
            fila["Reloj (Minutos)"] = Redondear(vector.Reloj);
            fila["Random Llegada Auto"] = Redondear(vector.RandomLlegadaAuto);
            fila["Tiempo Llegada Auto"] = Redondear(vector.TiempoLlegadaAuto);
            fila["Proxima Llegada Auto"] = Redondear(vector.ProximaLlegadaAuto);
            fila["Random Tipo Auto"] = Redondear(vector.RandomTipoAuto);
            fila["Tipo Auto"] = vector.TipoAuto.ObtenerDescripcion();
            fila["Random Tiempo Salida Auto"] = Redondear(vector.RandomTiempoRelojSalidaAuto);

            foreach (var sector in vector.PlayaEstacionamiento.Sectores)
            {
                fila[$"Auto [Sector {sector.Id}]"] = sector.TipoAuto?.ObtenerDescripcion() ?? string.Empty;
                fila[$"Estado [Sector {sector.Id}]"] = sector.EstadoSector is EstadoSector.Ocupado ? sector.Estado : string.Empty;
                fila[$"Salida [Sector {sector.Id}]"] = sector.TipoAuto is null ? string.Empty : Redondear(Convert.ToDouble(sector.Salida)).ToString();
            }

            tabla.Rows.Add(fila);

            fila["Cantidad Autos Sin Entrar"] = vector.CantidadAutosSinEntrar;
            //fila["Cantidad Sectores Ocupados"] = vector.CantidadSectoresOcupados;
        }

        public static void MostrarMensaje(string mensaje, string titulo)
        {
            MessageBox.Show(
                text: mensaje,
                caption: titulo,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void MostrarExcepcion(Exception excepcion)
        {
            MostrarMensaje(mensaje: excepcion.Message, titulo: "Error");
        }
    }
}