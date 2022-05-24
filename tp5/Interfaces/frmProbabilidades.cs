using System;
using System.Data;
using System.Windows.Forms;
using tp5.Modelos;

namespace tp5.Interfaces
{
    public partial class frmProbabilidades : Form
    {
        #region Propiedades    
        
        private ClsProbabilidades clsProbabilidades = new ClsProbabilidades();
        private string errorMessage = string.Empty;

        #endregion

        #region Constructor

        public frmProbabilidades()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void frmVariables_Load(object sender, EventArgs e)
        {
            if (ClsProbabilidades.DataTableTamaño == null)
                clsProbabilidades.GenerarTamanio();
            if (ClsProbabilidades.DataTableTiempo == null)
                clsProbabilidades.GenerarTiempo();
            
            dgTam.DataSource = ClsProbabilidades.DataTableTamaño;
            dgEst.DataSource = ClsProbabilidades.DataTableTiempo;
            txtCobro.Text = ClsProbabilidades.TiempoCobro.ToString();
            txtLlegadas.Text = ClsProbabilidades.IndiceLlegadas.ToString();

            dgEst.Columns[0].ReadOnly = dgEst.Columns[2].ReadOnly = dgEst.Columns[3].ReadOnly = dgEst.Columns[4].ReadOnly = true;
            dgTam.Columns[0].ReadOnly = dgTam.Columns[2].ReadOnly = dgTam.Columns[3].ReadOnly = dgTam.Columns[4].ReadOnly = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                clsProbabilidades.CalcularIntervalos(ClsProbabilidades.DataTableTamaño);
                clsProbabilidades.CalcularIntervalos(ClsProbabilidades.DataTableTiempo);
                ClsProbabilidades.IndiceLlegadas = Convert.ToInt32(txtLlegadas.Text);
                ClsProbabilidades.TiempoCobro = Convert.ToInt32(txtCobro.Text);
                MessageBox.Show("Probabilidades actualizadas correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show(errorMessage, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Metodos

        public bool Validar() 
        {
            decimal totalTiempo = 0;
            decimal totalTamaño = 0;

            if (txtCobro.Text == string.Empty || txtLlegadas.Text == string.Empty)
            {
                errorMessage = "Debe ingresar todos los parametros requeridos.";
                return false;
            }

            foreach (DataRow row in ClsProbabilidades.DataTableTiempo.Rows)
            {
                string tiempo = string.Empty;
                
                if (row[1].ToString().Contains("."))
                    tiempo = row[1].ToString().Replace(".", ",");

                else
                    tiempo = row[1].ToString();

                totalTiempo += Convert.ToDecimal(tiempo);
            }

            foreach (DataRow row in ClsProbabilidades.DataTableTamaño.Rows)
            {
                string tamaño = string.Empty;
                
                if (row[1].ToString().Contains("."))
                    tamaño = row[1].ToString().Replace(".", ",");

                else
                    tamaño = row[1].ToString();

                totalTamaño += Convert.ToDecimal(tamaño);
            }

            if (totalTiempo != 1 || totalTamaño != 1)
            {
                errorMessage = "Las probabilidades acumuladas deben ser iguales a 1";
                return false;
            }

            return true;
        }

        #endregion
    }
}
