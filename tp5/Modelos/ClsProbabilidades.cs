using System;
using System.Data;

namespace tp5.Modelos
{
    public class ClsProbabilidades
    {
        #region Propiedades
        public static DataTable DataTableTamaño;
        public static DataTable DataTableTiempo;
        public static int IndiceLlegadas = 13;
        public static int TiempoCobro = 2;
        #endregion


        #region Metodos 
        public DataTable GenerarTamanio()
        {
            DataTableTamaño = new DataTable();
            DataTableTamaño.Columns.Add("Tamaño");
            DataTableTamaño.Columns.Add("P()");
            DataTableTamaño.Columns.Add("P()AC");
            DataTableTamaño.Columns.Add("LimInf");
            DataTableTamaño.Columns.Add("LimSup");

            DataTableTamaño.Rows.Add("Pequeños", 0.45, 0.45, 0.00, 0.44);
            DataTableTamaño.Rows.Add("Grandes", 0.25, 0.70, 0.45, 0.69);
            DataTableTamaño.Rows.Add("Utilitarios", 0.30, 1, 0.70, 0.99);

            return DataTableTamaño;
        }
        public DataTable GenerarTiempo()
        {
            DataTableTiempo = new DataTable();
            DataTableTiempo.Columns.Add("Tiempo");
            DataTableTiempo.Columns.Add("P()");
            DataTableTiempo.Columns.Add("P()AC");
            DataTableTiempo.Columns.Add("LimInf");
            DataTableTiempo.Columns.Add("LimSup");

            DataTableTiempo.Rows.Add(1, 0.50, 0.50, 0.00, 0.49);
            DataTableTiempo.Rows.Add(2, 0.30, 0.80, 0.50, 0.79);
            DataTableTiempo.Rows.Add(3, 0.15, 0.95, 0.80, 0.94);
            DataTableTiempo.Rows.Add(4, 0.05, 1, 0.95, 0.99);

            return DataTableTiempo;
        }
        public DataTable CalcularIntervalos(DataTable tabla)
        {
            var acumulado = .0;
            var desde = .0;
            for (int i = 0; i < tabla.Rows.Count; i++)
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
