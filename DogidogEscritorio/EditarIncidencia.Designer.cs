namespace DogidogEscritorio
{
    partial class EditarIncidenciaForm
    {
        private System.ComponentModel.IContainer components = null;
        // Cambiamos TextBox por ComboBox
        private System.Windows.Forms.ComboBox cmbAsignado;

        private System.Windows.Forms.Button btnAbierto;
        private System.Windows.Forms.Button btnEnProgreso;
        private System.Windows.Forms.Button btnCerrado;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnMedia;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.Label lblAsignado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarIncidenciaForm));
            this.cmbAsignado = new System.Windows.Forms.ComboBox();
            this.btnAbierto = new System.Windows.Forms.Button();
            this.btnEnProgreso = new System.Windows.Forms.Button();
            this.btnCerrado = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnMedia = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.lblAsignado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbAsignado
            // 
            this.cmbAsignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsignado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbAsignado.Location = new System.Drawing.Point(23, 43);
            this.cmbAsignado.Name = "cmbAsignado";
            this.cmbAsignado.Size = new System.Drawing.Size(342, 28);
            this.cmbAsignado.TabIndex = 1;
            this.cmbAsignado.SelectedIndexChanged += new System.EventHandler(this.cmbAsignado_SelectedIndexChanged);
            // 
            // btnAbierto
            // 
            this.btnAbierto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAbierto.Location = new System.Drawing.Point(23, 107);
            this.btnAbierto.Name = "btnAbierto";
            this.btnAbierto.Size = new System.Drawing.Size(103, 32);
            this.btnAbierto.TabIndex = 3;
            this.btnAbierto.Text = "Abierto";
            this.btnAbierto.UseVisualStyleBackColor = true;
            // 
            // btnEnProgreso
            // 
            this.btnEnProgreso.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEnProgreso.Location = new System.Drawing.Point(137, 107);
            this.btnEnProgreso.Name = "btnEnProgreso";
            this.btnEnProgreso.Size = new System.Drawing.Size(126, 32);
            this.btnEnProgreso.TabIndex = 4;
            this.btnEnProgreso.Text = "En progreso";
            this.btnEnProgreso.UseVisualStyleBackColor = true;
            // 
            // btnCerrado
            // 
            this.btnCerrado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrado.Location = new System.Drawing.Point(274, 107);
            this.btnCerrado.Name = "btnCerrado";
            this.btnCerrado.Size = new System.Drawing.Size(91, 32);
            this.btnCerrado.TabIndex = 5;
            this.btnCerrado.Text = "Cerrado";
            this.btnCerrado.UseVisualStyleBackColor = true;
            // 
            // btnBaja
            // 
            this.btnBaja.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBaja.Location = new System.Drawing.Point(23, 181);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(91, 32);
            this.btnBaja.TabIndex = 7;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            // 
            // btnMedia
            // 
            this.btnMedia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMedia.Location = new System.Drawing.Point(126, 181);
            this.btnMedia.Name = "btnMedia";
            this.btnMedia.Size = new System.Drawing.Size(91, 32);
            this.btnMedia.TabIndex = 8;
            this.btnMedia.Text = "Media";
            this.btnMedia.UseVisualStyleBackColor = true;
            // 
            // btnAlta
            // 
            this.btnAlta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAlta.Location = new System.Drawing.Point(229, 181);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(91, 32);
            this.btnAlta.TabIndex = 9;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(208)))), ((int)(((byte)(225)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(80, 235);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(114, 37);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(217, 235);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 37);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(23, 85);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(56, 20);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrioridad.Location = new System.Drawing.Point(23, 160);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(73, 20);
            this.lblPrioridad.TabIndex = 6;
            this.lblPrioridad.Text = "Prioridad";
            // 
            // lblAsignado
            // 
            this.lblAsignado.AutoSize = true;
            this.lblAsignado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsignado.Location = new System.Drawing.Point(23, 21);
            this.lblAsignado.Name = "lblAsignado";
            this.lblAsignado.Size = new System.Drawing.Size(87, 20);
            this.lblAsignado.TabIndex = 0;
            this.lblAsignado.Text = "Asignado a";
            // 
            // EditarIncidenciaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(389, 299);
            this.Controls.Add(this.lblAsignado);
            this.Controls.Add(this.cmbAsignado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnAbierto);
            this.Controls.Add(this.btnEnProgreso);
            this.Controls.Add(this.btnCerrado);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnMedia);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditarIncidenciaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Incidencia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
