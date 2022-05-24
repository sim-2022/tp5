using System;
using System.Data;
using System.Windows.Forms;
using tp5.Modelos;

namespace tp5.Interfaces
{
    public partial class frmProbabilidades : Form
    {
        #region Propiedades      
        private  clsProbabilidades objVariables = new clsProbabilidades();
        private string errorMessage = "";
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
            if (clsProbabilidades.dtTamanio == null)
                objVariables.generarTamanio();
            if (clsProbabilidades.dtTiempo == null)
                objVariables.generarTiempo();
            
            dgTam.DataSource = clsProbabilidades.dtTamanio;
            dgEst.DataSource = clsProbabilidades.dtTiempo;
            txtCobro.Text = clsProbabilidades.tiempoCobro.ToString();
            txtLlegadas.Text = clsProbabilidades.indiceLlegadas.ToString();

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
                objVariables.Calcular_Intervalos(clsProbabilidades.dtTamanio);
                objVariables.Calcular_Intervalos(clsProbabilidades.dtTiempo);
                clsProbabilidades.indiceLlegadas = Convert.ToInt32(txtLlegadas.Text);
                clsProbabilidades.tiempoCobro = Convert.ToInt32(txtCobro.Text);
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
            if (txtCobro.Text == "" || txtLlegadas.Text == "")
            {
                errorMessage = "Debe ingresar todos los parametros requeridos.";
                return false;
            }

            foreach (DataRow row in clsProbabilidades.dtTiempo.Rows)
            {
                string tiempo = "";
                
                if (row[1].ToString().Contains("."))
                    tiempo = row[1].ToString().Replace(".", ",");
                else
                    tiempo = row[1].ToString();

                totalTiempo += Convert.ToDecimal(tiempo);
            }
            foreach (DataRow row in clsProbabilidades.dtTamanio.Rows)
            {
                string tamaño = "";
                
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
