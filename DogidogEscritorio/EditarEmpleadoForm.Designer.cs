﻿using System.Drawing;
using System.Windows.Forms;

namespace DogiDogEscritorio
{
    partial class EditarEmpleadoForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.TextBox txtPuesto;
    private System.Windows.Forms.CheckBox chkAdmin;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.Button btnResetPassword;
    private Panel panelPassword;

        protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarEmpleadoForm));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.FlowLayoutPanel();

            // Crear campos visuales reutilizables
            var panelPuesto = CrearCampo("Puesto:", out this.txtPuesto);
            var panelAdmin = CrearCheckbox("¿Es administrador?", out this.chkAdmin);
            panelPassword = CrearCampo("Nueva Contraseña:", out this.txtPassword);

            // Crear botones
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();

            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.MediumOrchid;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(432, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "✏️ Editar Empleado";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(20, 60, 20, 20);
            this.panel.Size = new System.Drawing.Size(432, 353);
            this.panel.TabIndex = 1;
            this.panel.WrapContents = false;

            // Añadir los paneles ordenadamente
            this.panel.Controls.Add(panelPuesto);
            this.panel.Controls.Add(panelAdmin);
            this.panel.Controls.Add(panelPassword);
            this.panel.Controls.Add(this.btnGuardar);
            this.panel.Controls.Add(this.btnResetPassword);

            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Size = new System.Drawing.Size(250, 40);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "💾 Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.Color.IndianRed;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.Size = new System.Drawing.Size(250, 40);
            this.btnResetPassword.TabIndex = 3;
            this.btnResetPassword.Text = "🔄 Resetear Contraseña";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Visible = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);

            // 
            // EditarEmpleadoForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(432, 353);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditarEmpleadoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Empleado";
        }

        private System.Windows.Forms.Panel CrearCampo(string label, out System.Windows.Forms.TextBox textbox)
    {
        var panel = new System.Windows.Forms.Panel() { Width = 400, Height = 60 };
        var lbl = new System.Windows.Forms.Label()
        {
            Text = label,
            Width = 400,
            Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
            ForeColor = System.Drawing.Color.MediumOrchid
        };

        textbox = new System.Windows.Forms.TextBox()
        {
            Width = 380,
            Font = new System.Drawing.Font("Segoe UI", 10)
        };

        textbox.Top = 25;
        panel.Controls.Add(lbl);
        panel.Controls.Add(textbox);
        return panel;
    }

    private System.Windows.Forms.Panel CrearCheckbox(string label, out System.Windows.Forms.CheckBox chk)
    {
        var panel = new System.Windows.Forms.Panel() { Width = 400, Height = 40 };
        chk = new System.Windows.Forms.CheckBox()
        {
            Text = label,
            AutoSize = true,
            Font = new System.Drawing.Font("Segoe UI", 10),
            ForeColor = System.Drawing.Color.MediumOrchid
        };
        panel.Controls.Add(chk);
        return panel;
    }

        private FlowLayoutPanel panel;
    }
}
