
namespace tp5.Interfaces
{
    partial class FrmProbabilidades
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbRango = new System.Windows.Forms.GroupBox();
            this.dgTam = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgEst = new System.Windows.Forms.DataGridView();
            this.txtIndiceLlegadas = new System.Windows.Forms.TextBox();
            this.txtTiempoCobro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbRango.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTam)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEst)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(592, 352);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(124, 35);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(432, 352);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(124, 35);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // gbRango
            // 
            this.gbRango.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRango.Controls.Add(this.dgTam);
            this.gbRango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbRango.Location = new System.Drawing.Point(8, 80);
            this.gbRango.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbRango.Name = "gbRango";
            this.gbRango.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbRango.Size = new System.Drawing.Size(534, 262);
            this.gbRango.TabIndex = 11;
            this.gbRango.TabStop = false;
            this.gbRango.Text = "Tamaños de Vehiculos";
            // 
            // dgTam
            // 
            this.dgTam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTam.Location = new System.Drawing.Point(10, 31);
            this.dgTam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgTam.Name = "dgTam";
            this.dgTam.RowHeadersWidth = 62;
            this.dgTam.Size = new System.Drawing.Size(490, 205);
            this.dgTam.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgEst);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(550, 80);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(561, 262);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiempo de Estacionamiento";
            // 
            // dgEst
            // 
            this.dgEst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEst.Location = new System.Drawing.Point(9, 31);
            this.dgEst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgEst.Name = "dgEst";
            this.dgEst.RowHeadersWidth = 62;
            this.dgEst.Size = new System.Drawing.Size(534, 205);
            this.dgEst.TabIndex = 1;
            // 
            // txtLlegadas
            // 
            this.txtIndiceLlegadas.Location = new System.Drawing.Point(442, 15);
            this.txtIndiceLlegadas.Name = "txtIndiceLlegadas";
            this.txtIndiceLlegadas.Size = new System.Drawing.Size(100, 26);
            this.txtIndiceLlegadas.TabIndex = 13;
            // 
            // txtCobro
            // 
            this.txtTiempoCobro.Location = new System.Drawing.Point(695, 15);
            this.txtTiempoCobro.Name = "txtTiempoCobro";
            this.txtTiempoCobro.Size = new System.Drawing.Size(100, 26);
            this.txtTiempoCobro.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Indice de llegadas: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(555, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tiempo de Cobro:";
            // 
            // frmProbabilidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 406);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTiempoCobro);
            this.Controls.Add(this.txtIndiceLlegadas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRango);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmProbabilidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVariables";
            this.Load += new System.EventHandler(this.FrmVariables_Load);
            this.gbRango.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTam)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbRango;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgTam;
        private System.Windows.Forms.DataGridView dgEst;
        private System.Windows.Forms.TextBox txtIndiceLlegadas;
        private System.Windows.Forms.TextBox txtTiempoCobro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}