using System;
using System.Data;
using System.Windows.Forms;
using tp5.Modelos;

namespace tp5.Interfaces
{
    public partial class FrmProbabilidades : Form
    {
        #region Propiedades    
        
        private readonly ClsProbabilidades _clsProbabilidades = new ClsProbabilidades();
        private string _errorMessage = string.Empty;

        #endregion

        #region Constructor

        public FrmProbabilidades() => InitializeComponent();

        #endregion

        #region Eventos

        private void FrmVariables_Load(object sender, EventArgs e)
        {
            if (ClsProbabilidades.DataTableTamaño == null)
                _clsProbabilidades.GenerarTamanio();

            if (ClsProbabilidades.DataTableTiempo == null)
                _clsProbabilidades.GenerarTiempo();
            
            dgTam.DataSource = ClsProbabilidades.DataTableTamaño;
            dgEst.DataSource = ClsProbabilidades.DataTableTiempo;

            txtCobro.Text = ClsProbabilidades.TiempoCobro.ToString();
            txtLlegadas.Text = ClsProbabilidades.IndiceLlegadas.ToString();

            dgEst.Columns[0].ReadOnly = dgEst.Columns[2].ReadOnly = dgEst.Columns[3].ReadOnly = dgEst.Columns[4].ReadOnly = true;
            dgTam.Columns[0].ReadOnly = dgTam.Columns[2].ReadOnly = dgTam.Columns[3].ReadOnly = dgTam.Columns[4].ReadOnly = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e) => Close();

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                _clsProbabilidades.CalcularIntervalos(ClsProbabilidades.DataTableTamaño);
                _clsProbabilidades.CalcularIntervalos(ClsProbabilidades.DataTableTiempo);

                ClsProbabilidades.IndiceLlegadas = Convert.ToInt32(txtLlegadas.Text);
                ClsProbabilidades.TiempoCobro = Convert.ToInt32(txtCobro.Text);

                MessageBox.Show("Probabilidades actualizadas correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show(_errorMessage, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Metodos

        private bool Validar() 
        {
            var totalTiempo = 0m;
            var totalTamaño = 0m;

            if (txtCobro.Text == string.Empty || txtLlegadas.Text == string.Empty)
            {
                _errorMessage = "Debe ingresar todos los parametros requeridos.";
                return false;
            }

            foreach (DataRow row in ClsProbabilidades.DataTableTiempo.Rows)
            {
                var tiempo = string.Empty;
                
                if (row[1].ToString().Contains("."))
                    tiempo = row[1].ToString().Replace(".", ",");

                else
                    tiempo = row[1].ToString();

                totalTiempo += Convert.ToDecimal(tiempo);
            }

            foreach (DataRow row in ClsProbabilidades.DataTableTamaño.Rows)
            {
                var tamaño = string.Empty;
                
                if (row[1].ToString().Contains("."))
                    tamaño = row[1].ToString().Replace(".", ",");

                else
                    tamaño = row[1].ToString();

                totalTamaño += Convert.ToDecimal(tamaño);
            }

            if (totalTiempo != 1 || totalTamaño != 1)
            {
                _errorMessage = "Las probabilidades acumuladas deben ser iguales a 1";
                return false;
            }

            return true;
        }

        #endregion
    }
}
