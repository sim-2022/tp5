namespace tp5.Interfaces
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVariables = new System.Windows.Forms.Button();
            this.lblTiempoGrafico = new System.Windows.Forms.Label();
            this.labelSimulaciones = new System.Windows.Forms.Label();
            this.gbRango = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.btnSimular = new System.Windows.Forms.Button();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.cbCantidadIteraciones = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gbRango.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnVariables);
            this.panel1.Controls.Add(this.lblTiempoGrafico);
            this.panel1.Controls.Add(this.labelSimulaciones);
            this.panel1.Controls.Add(this.gbRango);
            this.panel1.Controls.Add(this.btnSimular);
            this.panel1.Controls.Add(this.lblTiempo);
            this.panel1.Controls.Add(this.cbCantidadIteraciones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 137);
            this.panel1.TabIndex = 1;
            // 
            // btnVariables
            // 
            this.btnVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVariables.Location = new System.Drawing.Point(822, 97);
            this.btnVariables.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVariables.Name = "btnVariables";
            this.btnVariables.Size = new System.Drawing.Size(124, 35);
            this.btnVariables.TabIndex = 9;
            this.btnVariables.Text = "Probabilidades";
            this.btnVariables.UseVisualStyleBackColor = true;
            this.btnVariables.Click += new System.EventHandler(this.BtnVariables_Click);
            // 
            // lblTiempoGrafico
            // 
            this.lblTiempoGrafico.AutoSize = true;
            this.lblTiempoGrafico.Location = new System.Drawing.Point(18, 102);
            this.lblTiempoGrafico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTiempoGrafico.Name = "lblTiempoGrafico";
            this.lblTiempoGrafico.Size = new System.Drawing.Size(61, 20);
            this.lblTiempoGrafico.TabIndex = 8;
            this.lblTiempoGrafico.Text = "Tiempo";
            // 
            // labelSimulaciones
            // 
            this.labelSimulaciones.AutoSize = true;
            this.labelSimulaciones.Location = new System.Drawing.Point(18, 20);
            this.labelSimulaciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSimulaciones.Name = "labelSimulaciones";
            this.labelSimulaciones.Size = new System.Drawing.Size(103, 20);
            this.labelSimulaciones.TabIndex = 7;
            this.labelSimulaciones.Text = "Simulaciones";
            // 
            // gbRango
            // 
            this.gbRango.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRango.Controls.Add(this.btnFiltrar);
            this.gbRango.Controls.Add(this.txtDesde);
            this.gbRango.Controls.Add(this.txtHasta);
            this.gbRango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbRango.Location = new System.Drawing.Point(584, 18);
            this.gbRango.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbRango.Name = "gbRango";
            this.gbRango.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbRango.Size = new System.Drawing.Size(372, 74);
            this.gbRango.TabIndex = 6;
            this.gbRango.TabStop = false;
            this.gbRango.Text = "Rango";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(238, 26);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(124, 35);
            this.btnFiltrar.TabIndex = 8;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // txtDesde
            // 
            this.txtDesde.Location = new System.Drawing.Point(9, 29);
            this.txtDesde.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(103, 26);
            this.txtDesde.TabIndex = 4;
            // 
            // txtHasta
            // 
            this.txtHasta.Location = new System.Drawing.Point(123, 29);
            this.txtHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(103, 26);
            this.txtHasta.TabIndex = 5;
            // 
            // btnSimular
            // 
            this.btnSimular.Location = new System.Drawing.Point(208, 43);
            this.btnSimular.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(124, 35);
            this.btnSimular.TabIndex = 2;
            this.btnSimular.Text = "Simular";
            this.btnSimular.UseVisualStyleBackColor = true;
            this.btnSimular.Click += new System.EventHandler(this.BtnSimular_Click);
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(18, 82);
            this.lblTiempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(61, 20);
            this.lblTiempo.TabIndex = 3;
            this.lblTiempo.Text = "Tiempo";
            // 
            // cbCantidadIteraciones
            // 
            this.cbCantidadIteraciones.FormattingEnabled = true;
            this.cbCantidadIteraciones.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "1000",
            "10000",
            "100000"});
            this.cbCantidadIteraciones.Location = new System.Drawing.Point(18, 45);
            this.cbCantidadIteraciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCantidadIteraciones.Name = "cbCantidadIteraciones";
            this.cbCantidadIteraciones.Size = new System.Drawing.Size(180, 28);
            this.cbCantidadIteraciones.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvTabla);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 137);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 375);
            this.panel2.TabIndex = 2;
            // 
            // dgvTabla
            // 
            this.dgvTabla.AllowUserToAddRows = false;
            this.dgvTabla.AllowUserToDeleteRows = false;
            this.dgvTabla.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgvTabla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTabla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvTabla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTabla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTabla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dgvTabla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTabla.ColumnHeadersHeight = 34;
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabla.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTabla.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvTabla.Location = new System.Drawing.Point(0, 0);
            this.dgvTabla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabla.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTabla.RowHeadersWidth = 5;
            this.dgvTabla.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabla.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTabla.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabla.RowTemplate.ReadOnly = true;
            this.dgvTabla.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTabla.Size = new System.Drawing.Size(968, 375);
            this.dgvTabla.TabIndex = 0;
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 512);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trabajo Práctico 5 - Simulación";
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbRango.ResumeLayout(false);
            this.gbRango.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTiempoGrafico;

        private System.Windows.Forms.Button btnFiltrar;

        private System.Windows.Forms.Label labelSimulaciones;

        private System.Windows.Forms.GroupBox gbRango;

        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.TextBox txtHasta;

        private System.Windows.Forms.Label lblTiempo;

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvTabla;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.ComboBox cbCantidadIteraciones;
        private System.Windows.Forms.Button btnVariables;
    }
}