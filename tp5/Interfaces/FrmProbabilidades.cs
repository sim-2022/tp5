using System;
using System.Data;
using System.Windows.Forms;
using tp5.Modelos;
using tp5.Utilidades;

namespace tp5.Interfaces
{
    public partial class FrmProbabilidades : Form
    {
        #region Propiedades

        private readonly ClsProbabilidades _clsProbabilidades = new ClsProbabilidades();

        #endregion

        #region Constructor

        public FrmProbabilidades() => InitializeComponent();

        #endregion

        #region Eventos

        private void FrmVariables_Load(object sender, EventArgs e)
        {
            dgTam.DataSource = ClsProbabilidades.DataTableTamaño;
            dgEst.DataSource = ClsProbabilidades.DataTableTiempo;

            txtTiempoCobro.Text = ClsProbabilidades.TiempoCobro.ToString();
            txtIndiceLlegadas.Text = ClsProbabilidades.IndiceLlegadas.ToString();

            dgEst.Columns[0].ReadOnly = dgEst.Columns[2].ReadOnly = dgEst.Columns[3].ReadOnly = dgEst.Columns[4].ReadOnly = true;
            dgTam.Columns[0].ReadOnly = dgTam.Columns[2].ReadOnly = dgTam.Columns[3].ReadOnly = dgTam.Columns[4].ReadOnly = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e) => Close();

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarProbabilidades();
                var (tiempoCobro, indiceLlegadas) = ObtenerParametros();
                
                ClsProbabilidades.CalcularIntervalos(ClsProbabilidades.DataTableTamaño);
                ClsProbabilidades.CalcularIntervalos(ClsProbabilidades.DataTableTiempo);

                ClsProbabilidades.IndiceLlegadas = indiceLlegadas;
                ClsProbabilidades.TiempoCobro = tiempoCobro;

                UiHelper.MostrarMensaje(mensaje: "Probabilidades actualizadas correctamente", "Atención");
                Close();
            }
            catch (Exception excepcion)
            {
                UiHelper.MostrarExcepcion(excepcion);
            }
        }

        #endregion

        #region Metodos

        private (int tiempoCobro, int indiceLlegadas) ObtenerParametros()
        {
            if (!int.TryParse(txtIndiceLlegadas.Text, out var indiceLlegadas))
                throw new Exception("El indice de llegadas no es válido.");

            if (txtTiempoCobro.Text == string.Empty || txtIndiceLlegadas.Text == string.Empty)
                throw new Exception("Debe ingresar el tiempo de cobro y el indice de llegada.");

            if (!int.TryParse(txtTiempoCobro.Text, out var tiempoCobro))
                throw new Exception("El tiempo de cobro no es válido.");

            return (tiempoCobro, indiceLlegadas);
        }

        private void ValidarProbabilidades()
        {
            var totalTiempo = 0m;
            var totalTamaño = 0m;

            foreach (DataRow row in ClsProbabilidades.DataTableTiempo.Rows)
            {
                var tiempo = row[1].ToString().Contains(".") ? row[1].ToString().Replace(".", ",") : row[1].ToString();
                totalTiempo += Convert.ToDecimal(tiempo);
            }

            foreach (DataRow row in ClsProbabilidades.DataTableTamaño.Rows)
            {
                var tamaño = row[1].ToString().Contains(".") ? row[1].ToString().Replace(".", ",") : row[1].ToString();
                totalTamaño += Convert.ToDecimal(tamaño);
            }

            if (totalTiempo != 1 || totalTamaño != 1)
                throw new Exception("Las probabilidades acumuladas deben ser iguales a 1");
        }

        #endregion
    }
}