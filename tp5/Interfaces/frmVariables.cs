using System;
using System.Windows.Forms;
using tp5.Modelos;

namespace tp5.Interfaces
{
    public partial class frmVariables : Form
    {
        #region Propiedades      
        private  clsVariables objVariables = new clsVariables();
        #endregion

        #region Constructor
        public frmVariables()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void frmVariables_Load(object sender, EventArgs e)
        {
            if (clsVariables.dtTamanio == null)
                objVariables.generarTamanio();
            if (clsVariables.dtTiempo == null)
                objVariables.generarTiempo();
            
            dgTam.DataSource = clsVariables.dtTamanio;
            dgEst.DataSource = clsVariables.dtTiempo;
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objVariables.Calcular_Intervalos(clsVariables.dtTamanio);
            objVariables.Calcular_Intervalos(clsVariables.dtTiempo);
        }
    }
}
