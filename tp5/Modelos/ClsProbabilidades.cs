using System;
using System.Data;

namespace tp5.Modelos
{
    public class ClsProbabilidades
    {
        #region Propiedades

        private static DataTable _dataTableTamaño;
        public static DataTable DataTableTamaño
        {
            get => _dataTableTamaño ?? (_dataTableTamaño = GenerarTamaño());
            private set => _dataTableTamaño = value;
        }

        private static DataTable _dataTableTiempo;
        public static DataTable DataTableTiempo
        {
            get => _dataTableTiempo ?? (_dataTableTiempo = GenerarTiempo());
            private set => _dataTableTiempo = value;
        }

        public static int IndiceLlegadas = 13;
        public static int TiempoCobro = 2;

        #endregion

        #region Metodos

        private static DataTable GenerarTamaño()
        {
            DataTableTamaño = new DataTable();
            DataTableTamaño.Columns.Add("Tamaño");
            DataTableTamaño.Columns.Add("P()");
            DataTableTamaño.Columns.Add("P()AC");
            DataTableTamaño.Columns.Add("LimInf");
            DataTableTamaño.Columns.Add("LimSup");

            DataTableTamaño.Rows.Add("Pequeños", 0.45, 0.45, 0.00, 0.45);
            DataTableTamaño.Rows.Add("Grandes", 0.25, 0.70, 0.45, 0.70);
            DataTableTamaño.Rows.Add("Utilitarios", 0.30, 1, 0.70, 1);

            return DataTableTamaño;
        }

        private static DataTable GenerarTiempo()
        {
            DataTableTiempo = new DataTable();
            DataTableTiempo.Columns.Add("Tiempo");
            DataTableTiempo.Columns.Add("P()");
            DataTableTiempo.Columns.Add("P()AC");
            DataTableTiempo.Columns.Add("LimInf");
            DataTableTiempo.Columns.Add("LimSup");

            DataTableTiempo.Rows.Add(1, 0.50, 0.50, 0.00, 0.50);
            DataTableTiempo.Rows.Add(2, 0.30, 0.80, 0.50, 0.80);
            DataTableTiempo.Rows.Add(3, 0.15, 0.95, 0.80, 0.95);
            DataTableTiempo.Rows.Add(4, 0.05, 1, 0.95, 1);

            return DataTableTiempo;
        }

        public static DataTable CalcularIntervalos(DataTable tabla)
        {
            var acumulado = .0;
            var desde = .0;
            for (var i = 0; i < tabla.Rows.Count; i++)
            {
                acumulado += Convert.ToDouble(tabla.Rows[i][1]);
                tabla.Rows[i][2] = acumulado;
                tabla.Rows[i][3] = desde;
                var hasta = Convert.ToDouble(tabla.Rows[i][2]);
                tabla.Rows[i][4] = hasta - 0.01;
                desde = hasta;
            }

            return tabla;
        }

        #endregion
    }
}