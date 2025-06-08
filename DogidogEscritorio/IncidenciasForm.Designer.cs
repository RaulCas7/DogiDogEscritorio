using System;
using System.Windows.Forms;

namespace DogiDogEscritorio
{
    partial class IncidenciasForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbEstadoFiltro;
        private System.Windows.Forms.ComboBox cmbPrioridadFiltro;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblPrioridad;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAgregar = new System.Windows.Forms.Button();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.cmbPrioridadFiltro = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(208)))), ((int)(((byte)(225)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(620, 20);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(140, 35);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "➕ Incidencia";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanel.Location = new System.Drawing.Point(20, 80);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(740, 460);
            this.flowPanel.TabIndex = 7;
            this.flowPanel.WrapContents = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(20, 30);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(160, 22);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // cmbEstadoFiltro
            // 
            this.cmbEstadoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoFiltro.Items.AddRange(new object[] {
            "Todos",
            "Abierto",
            "En progreso",
            "Cerrado"});
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(200, 30);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(130, 24);
            this.cmbEstadoFiltro.TabIndex = 3;
            this.cmbEstadoFiltro.SelectedIndexChanged += new System.EventHandler(this.CmbEstadoFiltro_SelectedIndexChanged);
            // 
            // cmbPrioridadFiltro
            // 
            this.cmbPrioridadFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrioridadFiltro.Items.AddRange(new object[] {
            "Todas",
            "Baja",
            "Media",
            "Alta"});
            this.cmbPrioridadFiltro.Location = new System.Drawing.Point(350, 30);
            this.cmbPrioridadFiltro.Name = "cmbPrioridadFiltro";
            this.cmbPrioridadFiltro.Size = new System.Drawing.Size(130, 24);
            this.cmbPrioridadFiltro.TabIndex = 5;
            this.cmbPrioridadFiltro.SelectedIndexChanged += new System.EventHandler(this.CmbPrioridadFiltro_SelectedIndexChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(20, 10);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(100, 16);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "🔍 Buscar:";
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.Location = new System.Drawing.Point(200, 10);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 16);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "📌 Estado:";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrioridad.Location = new System.Drawing.Point(350, 10);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(100, 16);
            this.lblPrioridad.TabIndex = 4;
            this.lblPrioridad.Text = "⭐ Prioridad:";
            // 
            // IncidenciasForm
            // 
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstadoFiltro);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.cmbPrioridadFiltro);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.flowPanel);
            this.Name = "IncidenciasForm";
            this.Size = new System.Drawing.Size(784, 561);
            this.Load += new System.EventHandler(this.IncidenciasForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Event handlers para que funcione el filtro de búsqueda y combos

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            LoadIncidencias();
        }

        private void CmbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIncidencias();
        }

        private void CmbPrioridadFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIncidencias();
        }
    }

}
