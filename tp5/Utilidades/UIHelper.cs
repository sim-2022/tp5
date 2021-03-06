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

            columnas.Add(new DataColumn("Cantidad Autos Sin Entrar"));
            columnas.Add(new DataColumn("Ganancia Acumulada"));
            columnas.Add(new DataColumn("Porcentaje de Ocupacion"));
            for (var i = 0; i <= Vector.LstAutos.Count; i++)
            {
                columnas.Add(new DataColumn($"Tipo [Auto {i}]"));
                columnas.Add(new DataColumn($"Permanencia [Auto {i}]"));
                columnas.Add(new DataColumn($"Fin Estacionamiento [Auto {i}]"));
            }


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
            fila["Estado Cobro"] = vector.EstadoCobro;
            fila["Fin Cobro"] = Redondear(vector.FinCobro);
            fila["Cola Cobro"] = vector.ColaCobro;

            foreach (var auto in Vector.LstAutos)
            {
                fila[$"Tipo [Auto {auto.Id}]"] = auto.Tipo.ToString();
                fila[$"Permanencia [Auto {auto.Id}]"] = Redondear(auto.TiempoPermanencia).ToString();
                fila[$"Fin Estacionamiento [Auto {auto.Id}]"] = Redondear(auto.FinEstacionamiento).ToString();
            }

            tabla.Rows.Add(fila);

            fila["Cantidad Autos Sin Entrar"] = vector.CantidadAutosSinEntrar;
            fila["Ganancia Acumulada"] = Redondear(vector.Ganancia);
            fila["Porcentaje de Ocupacion"] = Redondear(vector.Porcentaje);
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