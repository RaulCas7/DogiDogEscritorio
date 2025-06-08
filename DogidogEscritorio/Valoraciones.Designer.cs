using System;
using System.Windows.Forms;

namespace DogiDogEscritorio
{
    partial class ValoracionesForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private DataGridView dgvValoraciones;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private Button btnEliminarCuenta;

        private DataGridViewTextBoxColumn colUsuarioValora;
        private DataGridViewTextBoxColumn colUsuarioValorado;
        private DataGridViewTextBoxColumn colPuntuacion;
        private DataGridViewTextBoxColumn colComentario;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvValoraciones = new System.Windows.Forms.DataGridView();
            this.colUsuarioValora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuarioValorado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPuntuacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnEliminarCuenta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoraciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(208)))), ((int)(((byte)(225)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(600, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "⭐ Valoraciones entre Usuarios";
            // 
            // dgvValoraciones
            // 
            this.dgvValoraciones.AllowUserToAddRows = false;
            this.dgvValoraciones.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(208)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValoraciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvValoraciones.ColumnHeadersHeight = 29;
            this.dgvValoraciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUsuarioValora,
            this.colUsuarioValorado,
            this.colPuntuacion,
            this.colComentario});
            this.dgvValoraciones.Location = new System.Drawing.Point(20, 120);
            this.dgvValoraciones.Name = "dgvValoraciones";
            this.dgvValoraciones.ReadOnly = true;
            this.dgvValoraciones.RowHeadersWidth = 51;
            this.dgvValoraciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValoraciones.Size = new System.Drawing.Size(900, 400);
            this.dgvValoraciones.TabIndex = 3;
            this.dgvValoraciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValoraciones_CellContentClick);
            // 
            // colUsuarioValora
            // 
            this.colUsuarioValora.HeaderText = "Usuario que valora";
            this.colUsuarioValora.MinimumWidth = 6;
            this.colUsuarioValora.Name = "colUsuarioValora";
            this.colUsuarioValora.ReadOnly = true;
            this.colUsuarioValora.Width = 180;
            // 
            // colUsuarioValorado
            // 
            this.colUsuarioValorado.HeaderText = "Usuario valorado";
            this.colUsuarioValorado.MinimumWidth = 6;
            this.colUsuarioValorado.Name = "colUsuarioValorado";
            this.colUsuarioValorado.ReadOnly = true;
            this.colUsuarioValorado.Width = 180;
            // 
            // colPuntuacion
            // 
            this.colPuntuacion.HeaderText = "Puntuación";
            this.colPuntuacion.MinimumWidth = 6;
            this.colPuntuacion.Name = "colPuntuacion";
            this.colPuntuacion.ReadOnly = true;
            // 
            // colComentario
            // 
            this.colComentario.HeaderText = "Comentario";
            this.colComentario.MinimumWidth = 6;
            this.colComentario.Name = "colComentario";
            this.colComentario.ReadOnly = true;
            this.colComentario.Width = 400;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(180, 80);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(400, 30);
            this.txtBuscar.TabIndex = 2;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBuscar.Location = new System.Drawing.Point(20, 80);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(160, 25);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "🔍 Buscar por email:";
            this.txtBuscar.TextChanged += new EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnEliminarCuenta
            // 
            this.btnEliminarCuenta.BackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCuenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminarCuenta.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCuenta.Location = new System.Drawing.Point(20, 540);
            this.btnEliminarCuenta.Name = "btnEliminarCuenta";
            this.btnEliminarCuenta.Size = new System.Drawing.Size(200, 40);
            this.btnEliminarCuenta.TabIndex = 4;
            this.btnEliminarCuenta.Text = "❌ Eliminar Cuenta";
            this.btnEliminarCuenta.UseVisualStyleBackColor = false;
            this.btnEliminarCuenta.Click += new System.EventHandler(this.btnEliminarCuenta_Click);
            // 
            // ValoracionesForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvValoraciones);
            this.Controls.Add(this.btnEliminarCuenta);
            this.Name = "ValoracionesForm";
            this.Size = new System.Drawing.Size(960, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoraciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

