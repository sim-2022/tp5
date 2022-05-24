using System;
using System.Data;

namespace tp5.Modelos
{
    public class clsProbabilidades
    {
        #region Propiedades
        public static DataTable dtTamanio;
        public static DataTable dtTiempo;
        public static int indiceLlegadas = 13;
        public static int tiempoCobro = 2;
        #endregion

        #region Constructor
        public clsProbabilidades() {}
        #endregion

        #region Metodos 
        public DataTable generarTamanio()
        {
            dtTamanio = new DataTable();
            dtTamanio.Columns.Add("Tamaño");
            dtTamanio.Columns.Add("P()");
            dtTamanio.Columns.Add("P()AC");
            dtTamanio.Columns.Add("LimInf");
            dtTamanio.Columns.Add("LimSup");

            dtTamanio.Rows.Add("Pequeños", 0.45, 0.45, 0.00, 0.44);
            dtTamanio.Rows.Add("Grandes", 0.25, 0.70, 0.45, 0.69);
            dtTamanio.Rows.Add("Utilitarios", 0.30, 1, 0.70, 0.99);

            return dtTamanio;
        }
        public DataTable generarTiempo()
        {
            dtTiempo = new DataTable();
            dtTiempo.Columns.Add("Tiempo");
            dtTiempo.Columns.Add("P()");
            dtTiempo.Columns.Add("P()AC");
            dtTiempo.Columns.Add("LimInf");
            dtTiempo.Columns.Add("LimSup");

            dtTiempo.Rows.Add(1, 0.50, 0.50, 0.00, 0.49);
            dtTiempo.Rows.Add(2, 0.30, 0.80, 0.50, 0.79);
            dtTiempo.Rows.Add(3, 0.15, 0.95, 0.80, 0.94);
            dtTiempo.Rows.Add(4, 0.05, 1, 0.95, 0.99);

            return dtTiempo;
        }
        public DataTable Calcular_Intervalos(DataTable tabla)
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
