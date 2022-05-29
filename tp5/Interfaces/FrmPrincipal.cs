using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using tp5.Modelos;
using tp5.Utilidades;

namespace tp5.Interfaces
{
    public partial class FrmPrincipal : Form
    {
        private const int MaximoIteraciones = 100_000;

        private List<(int Indice, Vector Vector)> ListaEstadosVector { get; set; }

        public FrmPrincipal()
        {
            InitializeComponent();
            ListaEstadosVector = new List<(int Indice, Vector Vector)>();
        }

        #region Eventos del Formulario

        private void BtnSimular_Click(object sender, EventArgs e) => Simular();

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            cbCantidadIteraciones.SelectedIndex = 1;
            CalcularRango(int.Parse(cbCantidadIteraciones.SelectedItem.ToString()));
            BtnSimular_Click(sender, e);
        }
        
        private void BtnVariables_Click(object sender, EventArgs e)
        {
            var form = new FrmProbabilidades();
            form.ShowDialog();
        }
        
        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                var (desde, hasta) = ObtenerRangoFiltro();
                MostrarFilas(numeroFilaDesde: desde, numeroFilaHasta: hasta);
            }
            catch (Exception exception)
            {
                UiHelper.MostrarExcepcion(exception);
            }
        }

        private (int Desde, int Hasta) ObtenerRangoFiltro()
        {
            const int minimo = 0;
            const int maximo = 10_000;

            if (!int.TryParse(txtDesde.Text, out var numeroFilaDesde) || numeroFilaDesde < minimo)
                throw new Exception("El número del límite inferior del rango es inválido.");

            if (!int.TryParse(txtHasta.Text, out var numeroFilaHasta) || numeroFilaHasta < minimo)
                throw new Exception("El número del límite superior del rango es inválido.");

            if (numeroFilaDesde >= numeroFilaHasta)
                throw new Exception($"El número del límite superior debe ser mayor al número del límite inferior.");

            var cantidadFilas = numeroFilaHasta - numeroFilaDesde;

            if (cantidadFilas < minimo || cantidadFilas > maximo)
                throw new Exception($"El número del filas a mostrar debe encontrarse entre {minimo} y {maximo}.");

            return (numeroFilaDesde, numeroFilaHasta);
        }

        #endregion

        #region Metodos privados

        private void Simular()
        {
            if (Vector.LstCobro.Any())
                Vector.LstCobro.Clear();

            Vector.Lambda = ClsProbabilidades.IndiceLlegadas;
            Vector.TiempoCobro = ClsProbabilidades.TiempoCobro;

            ListaEstadosVector.Clear();
            var timer = new Stopwatch();
            timer.Start();

            try
            {
                var numeroFila = 0;
                var cantidadIteraciones = ObtenerIteraciones();
                var vectorEstado = new VectorEstado();

                ListaEstadosVector.Add((numeroFila, vectorEstado.Actual));

                while (++numeroFila < cantidadIteraciones + 1)
                {
                    vectorEstado.CalcularSiguienteEstado();
                    ListaEstadosVector.Add((numeroFila, vectorEstado.Actual));
                }

                timer.Stop();
                dgvTabla.Refresh();
                ActualizarMensajeTiempo(timer, lblTiempo,"Procesamiento");
                MostrarFilas(numeroFilaDesde: 0, numeroFilaHasta: 1000);
            }
            catch (Exception ex)
            {
                UiHelper.MostrarExcepcion(ex);
            }
        }

        private int ObtenerIteraciones()
        {
            const int minimoRepeticiones = 1;

            if (!int.TryParse(cbCantidadIteraciones.Text, out var cantidadIteraciones))
                throw new Exception("El valor de las iteraciones es inválido.");

            if (cantidadIteraciones < minimoRepeticiones || cantidadIteraciones > MaximoIteraciones)
                throw new Exception(
                    $"El valor de las iteraciones debe encontrarse entre {minimoRepeticiones} y {MaximoIteraciones}.");

            return cantidadIteraciones;
        }

        private static void ActualizarMensajeTiempo(Stopwatch timer, Label label, string observacion)
        {
            var mensajeTiempoProcesamiento =
                $"Tiempo {observacion}: {timer.Elapsed.Minutes}' {timer.Elapsed.Seconds}'' {timer.Elapsed.Milliseconds}ms";
            label.Text = mensajeTiempoProcesamiento;
        }

        private void CalcularRango(int cantidad)
        {
            txtDesde.Text = 0.ToString();
            txtHasta.Text = cantidad.ToString();
        }
        
        private void MostrarFilas(int numeroFilaDesde, int numeroFilaHasta)
        {
            var timer = new Stopwatch();
            timer.Start();
            var tabla = UiHelper.CrearEstructuraTabla();

            ListaEstadosVector
                .Where(estado => estado.Indice >= numeroFilaDesde && estado.Indice <= numeroFilaHasta)
                .ToList()
                .ForEach(estado => UiHelper.AgregarFilaEnTabla(tabla, estado.Vector, estado.Indice));

            dgvTabla.DataSource = tabla;
            dgvTabla.Refresh();

            timer.Stop();
            ActualizarMensajeTiempo(timer, lblTiempoGrafico, "Procesamiento de Gráficos");

        }
        
        #endregion
    }
}