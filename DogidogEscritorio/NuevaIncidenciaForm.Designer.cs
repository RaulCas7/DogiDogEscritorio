namespace DogidogEscritorio
{
    partial class NuevaIncidenciaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblAsignado;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbAsignado;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnMedia;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnAbierto;
        private System.Windows.Forms.Button btnEnProgreso;
        private System.Windows.Forms.Button btnCerrado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaIncidenciaForm));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblAsignado = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnMedia = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnAbierto = new System.Windows.Forms.Button();
            this.btnEnProgreso = new System.Windows.Forms.Button();
            this.btnCerrado = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbAsignado = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(23, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(57, 23);
            this.lblTitulo.TabIndex = 20;
            this.lblTitulo.Text = "Título";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.Location = new System.Drawing.Point(23, 48);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(103, 23);
            this.lblDescripcion.TabIndex = 21;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblAsignado
            // 
            this.lblAsignado.AutoSize = true;
            this.lblAsignado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAsignado.Location = new System.Drawing.Point(23, 139);
            this.lblAsignado.Name = "lblAsignado";
            this.lblAsignado.Size = new System.Drawing.Size(85, 23);
            this.lblAsignado.TabIndex = 22;
            this.lblAsignado.Text = "Asignado";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPrioridad.Location = new System.Drawing.Point(23, 192);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(85, 23);
            this.lblPrioridad.TabIndex = 23;
            this.lblPrioridad.Text = "Prioridad";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(23, 256);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(63, 23);
            this.lblEstado.TabIndex = 24;
            this.lblEstado.Text = "Estado";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(23, 21);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(342, 22);
            this.txtTitulo.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(23, 69);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(342, 64);
            this.txtDescripcion.TabIndex = 1;
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(23, 213);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(91, 32);
            this.btnBaja.TabIndex = 3;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            // 
            // btnMedia
            // 
            this.btnMedia.Location = new System.Drawing.Point(126, 213);
            this.btnMedia.Name = "btnMedia";
            this.btnMedia.Size = new System.Drawing.Size(91, 32);
            this.btnMedia.TabIndex = 4;
            this.btnMedia.Text = "Media";
            this.btnMedia.UseVisualStyleBackColor = true;
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(229, 213);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(91, 32);
            this.btnAlta.TabIndex = 5;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            // 
            // btnAbierto
            // 
            this.btnAbierto.Location = new System.Drawing.Point(23, 277);
            this.btnAbierto.Name = "btnAbierto";
            this.btnAbierto.Size = new System.Drawing.Size(91, 32);
            this.btnAbierto.TabIndex = 6;
            this.btnAbierto.Text = "Abierto";
            this.btnAbierto.UseVisualStyleBackColor = true;
            // 
            // btnEnProgreso
            // 
            this.btnEnProgreso.Location = new System.Drawing.Point(126, 277);
            this.btnEnProgreso.Name = "btnEnProgreso";
            this.btnEnProgreso.Size = new System.Drawing.Size(114, 32);
            this.btnEnProgreso.TabIndex = 7;
            this.btnEnProgreso.Text = "En progreso";
            this.btnEnProgreso.UseVisualStyleBackColor = true;
            // 
            // btnCerrado
            // 
            this.btnCerrado.Location = new System.Drawing.Point(251, 277);
            this.btnCerrado.Name = "btnCerrado";
            this.btnCerrado.Size = new System.Drawing.Size(91, 32);
            this.btnCerrado.TabIndex = 8;
            this.btnCerrado.Text = "Cerrado";
            this.btnCerrado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(57, 331);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(114, 32);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(206, 331);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 32);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // cmbAsignado
            // 
            this.cmbAsignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsignado.Location = new System.Drawing.Point(23, 160);
            this.cmbAsignado.Name = "cmbAsignado";
            this.cmbAsignado.Size = new System.Drawing.Size(342, 24);
            this.cmbAsignado.TabIndex = 2;
            // 
            // NuevaIncidenciaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 384);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblAsignado);
            this.Controls.Add(this.cmbAsignado);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnMedia);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnAbierto);
            this.Controls.Add(this.btnEnProgreso);
            this.Controls.Add(this.btnCerrado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NuevaIncidenciaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Incidencia";
            this.Load += new System.EventHandler(this.NuevaIncidenciaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
